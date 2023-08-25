using ApaGroup.Framework.Dal.Context.Securities.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;

namespace ApaGroup.Framework.Dal.Context.Extensions
{
    public static class ObjectContextExtension
    {
        #region Public Methods

        /// <summary>
        /// ApplyChanges takes the changes in a connected set of entities and applies them to an ObjectContext.
        /// </summary>
        /// <typeparam name="TDataModelType">Expected type of the EntitySet</typeparam>
        /// <param name="inContext">The ObjectContext to which changes will be applied.</param>
        /// <param name="inAuthenticationDataObject"></param>
        /// <param name="inDataModel">The entity serving as the entry point of the object graph that contains changes.</param>
        /// <param name="inDataModelMasterParent">The master parent of the DataModel.</param>
        /// <param name="inDefaultValue">Default values of the added data model.</param>
        /// <param name="inCheckPropertyValueChangingSecurityControl">Specify whether should be checked 'PropertyValueChangingSecurityControl'.</param>
        public static void ApplyChanges<TDataModelType>(this DbContext inContext, AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, Type inDataModelMasterParent, Dictionary<string, object> inDefaultValue, bool inCheckPropertyValueChangingSecurityControl) where TDataModelType : class, IDataModel
        {
            if (inDataModel.IsDirty)
            {
                inContext.Set(inDataModelMasterParent).Add(inDataModel);

                ((IObjectContextAdapter)inContext).ObjectContext.AcceptAllChanges();

                switch (inDataModel.State)
                {
                    #region DataModelState.Added

                    case DataModelState.Added:

                        var addedEntry = inContext.Entry(inDataModel);

                        addedEntry.State = EntityState.Added;

                        if (!inAuthenticationDataObject.IsAdministratorUser() && inCheckPropertyValueChangingSecurityControl)
                        {
                            SecurityControlHelper.CheckPropertyValueChangingSecurityControl(inAuthenticationDataObject, inDataModel, addedEntry, inDefaultValue);
                        }

                        break;

                    #endregion

                    #region DataModelState.Deleted

                    case DataModelState.Deleted:

                        inContext.Entry(inDataModel).State = EntityState.Deleted;

                        break;

                    #endregion

                    #region DataModelState.Modified

                    case DataModelState.Modified:

                        var editedEntry = inContext.Entry(inDataModel);

                        editedEntry.State = EntityState.Unchanged;

                        if (!inAuthenticationDataObject.IsAdministratorUser() && inCheckPropertyValueChangingSecurityControl)
                        {
                            SecurityControlHelper.CheckPropertyValueChangingSecurityControl(inAuthenticationDataObject, inDataModel, editedEntry, inDefaultValue);
                        }

                        break;

                    #endregion
                }
            }
        }

        #endregion
    }
}
