using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Basis.Locks;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Securities.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Securities.Enumerations;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level6)]
    internal sealed class PropertyValueChangingSecurityControl : SecurityControlBase
    {
        #region Constructors

        private PropertyValueChangingSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private static readonly InternalLock _InternalLock = new InternalLock();

        private static readonly ConcurrentDictionary<Type, IList<ValueChangePreventerData>> _DatabaseValueResetPreventerAttributeCache = new ConcurrentDictionary<Type, IList<ValueChangePreventerData>>(10, 5000);

        private static readonly PropertyValueChangingSecurityControl _Instance = new PropertyValueChangingSecurityControl();

        #endregion

        #region Private Properties

        private static InternalLock InternalLock
        {
            get { return _InternalLock; }
        }

        private static ConcurrentDictionary<Type, IList<ValueChangePreventerData>> DatabaseValueResetPreventerAttributeCache
        {
            get { return _DatabaseValueResetPreventerAttributeCache; }
        }

        #endregion

        #region Private Methods

        private static IList<ValueChangePreventerData> GetValueResetPreventerAttributes(Type inDataModelType)
        {
            if (!DatabaseValueResetPreventerAttributeCache.ContainsKey(inDataModelType))
            {
                lock (InternalLock)
                {
                    if (!DatabaseValueResetPreventerAttributeCache.ContainsKey(inDataModelType))
                    {
                        var properties =
                            ReflectionHelper.GetProperties(inDataModelType)
                                .Where(
                                    property =>
                                        ReflectionHelper.GetCustomAttributes<ValueChangePreventerAttribute>(property,
                                            true)
                                            .Any())
                                .Select(
                                    property =>
                                        new ValueChangePreventerData
                                        {
                                            FieldName = property.Name,
                                            AppliedAccountTypes =
                                                ReflectionHelper.GetCustomAttributes<ValueChangePreventerAttribute>(
                                                    property, true).First().AppliedAccountTypes
                                        })
                                .ToList();

                        if (!DatabaseValueResetPreventerAttributeCache.TryAdd(inDataModelType, properties))
                        {
                            throw ExceptionFactory.GetNewFactoryException(null,
                                "The preventer attributes of '" + inDataModelType +
                                "' could not add to the attributes cache.");
                        }
                    }
                }
            }

            return DatabaseValueResetPreventerAttributeCache[inDataModelType];
        }

        #endregion

        #region Private Class

        private class ValueChangePreventerData
        {
            #region Public Properties

            public string FieldName { get; set; }

            public AccountType AppliedAccountTypes { private get; set; }

            #endregion

            #region Public Methods

            public bool HasUserTypeInAppliedAccountTypes(UserType inUserType)
            {
                bool result;

                switch (inUserType)
                {
                    case UserType.AdminAccessLevel:
                        result = AppliedAccountTypes.HasFlag(AccountType.Administrator);
                        break;
                    case UserType.RequirementAccessLevel:
                        result = AppliedAccountTypes.HasFlag(AccountType.Requirement);
                        break;
                    case UserType.BuyerAccessLevel:
                        result = AppliedAccountTypes.HasFlag(AccountType.Buyer);
                        break;
                    case UserType.SellerAccessLevel:
                        result = AppliedAccountTypes.HasFlag(AccountType.Seller);
                        break;
                    default:
                        result = true;
                        break;
                }

                return result;
            }

            #endregion
        }

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- AuthenticationDataObject, 2- IDataModel, 3- DbEntityEntry, 4- DefaultValues</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var authenticationDataObject = (AuthenticationDataObject)inObjects[0];
            var dataModel = (IDataModel)inObjects[1];
            var dbEntityEntry = (DbEntityEntry)inObjects[2];
            var defaultValues = (Dictionary<string, object>)inObjects[3];

            IList<ValueChangePreventerData> preventedPropertyValueChangedDatas = GetValueResetPreventerAttributes(dataModel.GetType());

            if (preventedPropertyValueChangedDatas.Any())
            {
                #region Check 'RowVersion' Field (If any data model has this attribute on 'RowVersion' property for the specific user type, the data model can not be changed by this user type.)

                var rowVersionData = preventedPropertyValueChangedDatas.FirstOrDefault(item => item.FieldName == "RowVersion");
                
                if(rowVersionData != null)
                {
                    if (rowVersionData.HasUserTypeInAppliedAccountTypes(authenticationDataObject.UserType))
                    {
                        throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.PropertyValueChangingPrevented.ToString());
                    }
                }

                #endregion

                var databaseValues = dbEntityEntry.GetDatabaseValues();

                if (dbEntityEntry.State != EntityState.Added)
                {
                    #region Check ConcurrencyException

                    if (databaseValues == null)
                    {
                        throw ExceptionFactory.GetNewConcurrencyException(null, "Current entity was deleted.");
                    }

                    if (!dataModel.RowVersion.Equals(databaseValues["RowVersion"]))
                    {
                        throw ExceptionFactory.GetNewConcurrencyException(null, "Current entity was changed.");
                    }

                    #endregion

                    #region Set Original Values And Check PreventedPropertyValueChanged

                    dbEntityEntry.OriginalValues.SetValues(databaseValues);

                    var changedProperties =
                        dbEntityEntry.CurrentValues.PropertyNames.Where(p => dbEntityEntry.Property(p).IsModified)
                            .ToList();

                    if (preventedPropertyValueChangedDatas.Any(data => changedProperties.Contains(data.FieldName) && data.HasUserTypeInAppliedAccountTypes(authenticationDataObject.UserType)))
                    {
                        throw ExceptionFactory.GetNewSecurityControlException(
                            SecurityControlType.PropertyValueChangingPrevented.ToString());
                    }

                    #endregion
                }
                else
                {
                    #region Check ConcurrencyException

                    if (databaseValues != null)
                    {
                        throw ExceptionFactory.GetNewConcurrencyException(null, "Current entity is existed.");
                    }

                    #endregion

                    #region Set Original Values And Check PreventedPropertyValueChanged

                    foreach (var data in preventedPropertyValueChangedDatas)
                    {
                        if (data.HasUserTypeInAppliedAccountTypes(authenticationDataObject.UserType))
                        {
                            var property = ReflectionHelper.GetProperties(dataModel.GetType()).First(p => p.Name == data.FieldName);

                            if (defaultValues.ContainsKey(property.Name))
                            {
                                if (!ReflectionHelper.GetPropertyValue<object>(dataModel, data.FieldName).Equals(defaultValues[property.Name]))
                                {
                                    throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.PropertyValueChangingPrevented.ToString());
                                }
                            }
                        }
                    }

                    #endregion
                }
            }
        }

        #endregion

        #region Public Properties

        public static PropertyValueChangingSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
