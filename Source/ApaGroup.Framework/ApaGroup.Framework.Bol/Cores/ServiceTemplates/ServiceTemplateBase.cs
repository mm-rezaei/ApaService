
using ApaGroup.Framework.Dal.Context.Securities.Contexts;
using ApaGroup.Framework.Dal.Context.Securities.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApaGroup.Framework.Bol.Cores.ServiceTemplates
{
    public abstract class ServiceTemplateBase<TDataModelType>
        where TDataModelType : class, IDataModel, new()
    {

        #region Protected Methods

        protected short GetCurrentDatabaseObject()
        {
            return DatabaseObjectKeyHelper.GetTypeKey(typeof(TDataModelType));
        }

        protected SecurityPrivacySecureDataDataModel GetNewSecureDataModel(int inAccountId, short inTableId, int inSecureId)
        {
            return new SecurityPrivacySecureDataDataModel
            {
                AccountId = inAccountId,
                TableId = inTableId,
                SecureId = inSecureId
            };
        }

        protected SecurityPrivacySecureDataDataModel GetNewSecureDataModel(int inAccountId, int inSecureId)
        {
            return GetNewSecureDataModel(inAccountId, GetCurrentDatabaseObject(), inSecureId);
        }

        protected SecurityPrivacySecureDataDataModel GetDeletedSecureDataModel(int inAccountId, short inTableId, int inSecureId)
        {
            SecurityPrivacySecureDataDataModel result;

            using (var context = new SecurityContext())
            {
                result =
                    context.FetchEntity<SecurityPrivacySecureDataDataModel>(
                        entity =>
                            entity.AccountId == inAccountId && entity.TableId == inTableId &&
                            entity.SecureId == inSecureId).FirstOrDefault();
            }

            if (result != null)
            {
                result.MarkAsDeleted();
            }

            return result;
        }

        protected SecurityPrivacySecureDataDataModel GetDeletedSecureDataModel(int inAccountId, int inSecureId)
        {
            return GetDeletedSecureDataModel(inAccountId, GetCurrentDatabaseObject(), inSecureId);
        }

        #endregion

        #region Public Methods

        public abstract TDataModelType AfterModelCreation(TDataModelType inDataModel);

        public abstract Expression<Func<TDataModelType, bool>> BeforeDataRetrieve(Expression<Func<TDataModelType, bool>> inPredicate);

        public abstract IQueryable<TDataModelType> AfterDataRetrieve(IQueryable<TDataModelType> inDataModels);

        public abstract void BeforeProcessActionRequest(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction);

        public abstract void BeforeValidation(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction);

        public abstract void AfterValidation(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction);

        public abstract void BeforeSaveToDataBase(TDataModelType inDataModel, WorkflowAction inWorkflowAction);

        public abstract IList<SecurityPrivacySecureDataDataModel> GetSecureDataForAddOrDelete(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction);

        public abstract void AfterSaveToDataBase(TDataModelType inDataModel, WorkflowAction inWorkflowAction);

        public abstract void AfterProcessActionRequest(TDataModelType inDataModel, WorkflowAction inWorkflowAction);

        #endregion
    }
}
