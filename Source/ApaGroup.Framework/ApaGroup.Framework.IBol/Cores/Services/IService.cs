
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.IBol.Cores.Services
{
    public interface IService<TDataModelType> where TDataModelType : IDataModel
    {
        #region Public Methods

        int Count();

        int Count(Expression<Func<TDataModelType, bool>> inPredicate);

        TDataModelType CreateEntity();

        IQueryable<TDataModelType> Read();

        IQueryable<TDataModelType> Read(string inIncludedDataModel);

        IQueryable<TDataModelType> Read(IEnumerable<string> inIncludedDataModels);

        IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate);

        IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate, string inIncludedDataModel);

        IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate, IEnumerable<string> inIncludedDataModels);

        IEnumerable<IValidationMessageDataObject> Check(WorkflowAction inWorkflowAction, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules, bool inCollectAllValidationMessage);
        
        IEnumerable<IValidationMessageDataObject> Check(WorkflowAction inWorkflowAction, TDataModelType inDataModel, bool inCollectAllValidationMessage);

        void Save(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction, object inRelatedObjectsForCheckingRules);

        void Save(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction);

        void Save(AuthenticationDataObject inAuthenticationDataObject, IList<TDataModelType> inDataModels, WorkflowAction inWorkflowAction);

        void Delete(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules);

        void Delete(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel);

        void Delete(AuthenticationDataObject inAuthenticationDataObject, IList<TDataModelType> inDataModels);

        IList<WorkflowAction> GetNextActions(WorkflowState inWorkflowState);

        IList<WorkflowAction> GetNextActions(TDataModelType inDataModel);

        WorkflowState ConvertWorkflowState(string inWorkflowState);

        string ConvertWorkflowState(WorkflowState inWorkflowState);

        WorkflowAction ConvertWorkflowAction(string inWorkflowAction);

        string ConvertWorkflowAction(WorkflowAction inWorkflowAction);

        #endregion
    }
}