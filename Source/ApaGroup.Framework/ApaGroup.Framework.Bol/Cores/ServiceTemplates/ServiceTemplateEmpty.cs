using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Shared.Enumerations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApaGroup.Framework.Bol.Cores.ServiceTemplates
{
    public abstract class ServiceTemplateEmpty<TDataModelType> : ServiceTemplateBase<TDataModelType>
         where TDataModelType : class, IDataModel, new()
    {
        #region Public Methods

        public override TDataModelType AfterModelCreation(TDataModelType inDataModel)
        {
            return inDataModel;
        }

        public override Expression<Func<TDataModelType, bool>> BeforeDataRetrieve(Expression<Func<TDataModelType, bool>> inPredicate)
        {
            return inPredicate;
        }

        public override IQueryable<TDataModelType> AfterDataRetrieve(IQueryable<TDataModelType> inDataModels)
        {
            return inDataModels;
        }

        public override void BeforeProcessActionRequest(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction)
        {

        }

        public override void BeforeValidation(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction)
        {

        }

        public override void AfterValidation(TDataModelType inDataModel, ref WorkflowAction inWorkflowAction)
        {

        }

        public override void BeforeSaveToDataBase(TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {

        }

        public override void AfterSaveToDataBase(TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {

        }

        public override void AfterProcessActionRequest(TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {

        }

        #endregion
    }
}
