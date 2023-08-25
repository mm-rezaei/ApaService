using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Bol.Cores.ServiceTemplates;
using ApaGroup.Framework.Bol.Cores.Validations;
using ApaGroup.Framework.Bol.Cores.WorkFlowMachines;
using ApaGroup.Framework.Bol.Validations;
using ApaGroup.Framework.Dal.Context.Cores.Contexts;
using ApaGroup.Framework.Dal.Context.Securities.Contexts;
using ApaGroup.Framework.Dal.DataStructure.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using ApaGroup.Framework.IBol.Cores.Services;
using ApaGroup.Framework.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace ApaGroup.Framework.Bol.Cores.Services
{
    public abstract class ServiceBase<
        TConstantType,
        TDatabaseContextConstantType,
        TDatabaseContextType,
        TDataModelType,
        TServiceTemplateType,
        TWorkflowActionType,
        TWorkflowStateType,
        TWorkflowMachineType,
        TValidationRuleType,
        TServiceArgsType> : ApaGroupBase<TConstantType>, IService<TDataModelType>
        where TConstantType : ConstantBase, new()
        where TDatabaseContextConstantType : ConstantBase, new()
        where TDatabaseContextType : DatabaseContextBase<TDatabaseContextConstantType>, new()
        where TDataModelType : class, IDataModel, new()
        where TServiceTemplateType : ServiceTemplateBase<TDataModelType>, new()
        where TWorkflowActionType : WorkflowActionBase
        where TWorkflowStateType : WorkflowStateBase
        where TWorkflowMachineType : WorkflowMachineBase, new()
        where TValidationRuleType : ValidationRuleBase<TDataModelType>, new()
        where TServiceArgsType : IServiceArgs
    {
        #region Constructors

        protected ServiceBase(TServiceArgsType inServiceArgs, ContextScopeBase inContextScope)
        {
            InitializeProperties(inServiceArgs, inContextScope);
        }

        #endregion

        #region Private Fields

        private TServiceTemplateType _ServiceTemplate;

        private ValidationRuleChecker<TDataModelType, TValidationRuleType> _RuleChecker;

        private TWorkflowMachineType _WorkflowMachine;

        #endregion

        #region Private Properties

        private ContextScopeBase ContextScope { get; set; }

        private TServiceTemplateType ServiceTemplate
        {
            get
            {
                return _ServiceTemplate ?? (_ServiceTemplate = new TServiceTemplateType());
            }
        }

        private ValidationRuleChecker<TDataModelType, TValidationRuleType> RuleChecker
        {
            get
            {
                return _RuleChecker ?? (_RuleChecker = new ValidationRuleChecker<TDataModelType, TValidationRuleType>());
            }
        }

        #endregion

        #region Private Methods

        private void InitializeProperties(TServiceArgsType inServiceArgs, ContextScopeBase inContextScope)
        {
            ContextScope = inContextScope;

            InitializeFromServiceArgs(inServiceArgs);
        }

        private TDatabaseContextType GetNewDatabaseContextInstance(ContextScopeBase inContextScope)
        {
            var result = new TDatabaseContextType();

            result.InitializeDatabaseContextScope(inContextScope);

            return result;
        }

        #endregion

        #region Protected Properties

        protected TWorkflowMachineType WorkflowMachine
        {
            get { return _WorkflowMachine ?? (_WorkflowMachine = new TWorkflowMachineType()); }
        }

        protected abstract bool IsDeleteActionValid { get; }

        protected abstract bool IsAnySaveActionValid { get; }

        #endregion

        #region Protected Methods

        protected abstract void InitializeFromServiceArgs(TServiceArgsType inServiceArgs);

        protected WorkflowPropertyAttribute GetWorkflowPropertyAttribute()
        {
            var result = Assistant.Reflection.GetCustomAttributes<WorkflowPropertyAttribute, TDataModelType>(true)
                .FirstOrDefault();

            return result;
        }

        protected WorkflowState GetModelState(TDataModelType inDataModel)
        {
            WorkflowState result;

            var workflowPropertyAttribute = GetWorkflowPropertyAttribute();

            if (workflowPropertyAttribute == null)
            {
                switch (inDataModel.State)
                {
                    case DataModelState.Added:
                    case DataModelState.AddedDeleted:
                        result = WorkflowStateBase.UnSaved;
                        break;
                    case DataModelState.Deleted:
                    case DataModelState.Modified:
                    case DataModelState.Unchanged:
                        result = WorkflowStateBase.None;
                        break;
                    default:
                        throw ExceptionFactory.GetNewWorkflowStateNotFoundException(null);
                }
            }
            else
            {
                var workflowValue = Assistant.Reflection.GetPropertyValue<string>(inDataModel, workflowPropertyAttribute.WorkflowPropertyName);

                result = ConvertWorkflowState(workflowValue);
            }

            return result;
        }

        protected void SetModelState(TDataModelType inDataModel, WorkflowState inWorkflowState)
        {
            var workflowPropertyAttribute = GetWorkflowPropertyAttribute();

            if (workflowPropertyAttribute != null)
            {
                Assistant.Reflection.SetPropertyValue(inDataModel, workflowPropertyAttribute.WorkflowPropertyName, ConvertWorkflowState(inWorkflowState));
            }
        }

        protected void SetModelState(TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {
            var workflowPropertyAttribute = GetWorkflowPropertyAttribute();

            if (workflowPropertyAttribute != null)
            {
                var currentState = GetModelState(inDataModel);

                var nextState = WorkflowMachine.GetNextState(currentState, inWorkflowAction);

                var nextStateValue = ConvertWorkflowState(nextState);

                Assistant.Reflection.SetPropertyValue(inDataModel, workflowPropertyAttribute.WorkflowPropertyName, nextStateValue);
            }
        }

        protected bool IsActionValid(TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {
            var result = WorkflowMachine.GetNextActions(GetModelState(inDataModel)).Contains(inWorkflowAction);

            return result;
        }

        protected virtual void Save(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction, bool inCheckPropertyValueChangingSecurityControl, object inRelatedObjectsForCheckingRules)
        {
            using (var transaction = new TransactionScope())
            {
                // 1- Check WorkflowAction and DataModelState
                if (!IsAnySaveActionValid)
                {
                    throw ExceptionFactory.GetNewInvalidServiceActionException("Any save action isn't valid for the service of '" + inDataModel.GetType() + "'.");
                }

                if (inWorkflowAction == WorkflowAction.Delete)
                {
                    inDataModel.MarkAsDeleted();
                }

                if (!IsDeleteActionValid &&
                    (inWorkflowAction == WorkflowAction.Delete ||
                    inDataModel.State == DataModelState.Deleted ||
                    inDataModel.State == DataModelState.AddedDeleted))
                {
                    throw ExceptionFactory.GetNewInvalidServiceActionException("The delete action isn't valid for the service of '" + inDataModel.GetType() + "'.");
                }

                if (inDataModel.State == DataModelState.AddedDeleted)
                {
                    return;
                }

                // 2- BeforeProcessActionRequest
                ServiceTemplate.BeforeProcessActionRequest(inDataModel, ref inWorkflowAction);

                #region Check Action Validation

                if (!IsActionValid(inDataModel, inWorkflowAction))
                {
                    var validActions = string.Empty;

                    foreach (var action in GetNextActions(inDataModel))
                    {
                        if (validActions != string.Empty)
                        {
                            validActions += " ,";
                        }

                        validActions += ConvertWorkflowAction(action);
                    }

                    throw ExceptionFactory.GetNewInvalidServiceActionException("'" +
                                                                                       ConvertWorkflowAction(
                                                                                           inWorkflowAction) +
                                                                                       "' is not a valid action. The valid actions are '" +
                                                                                       validActions + "'");
                }

                #endregion

                // 3- BeforeValidation
                ServiceTemplate.BeforeValidation(inDataModel, ref inWorkflowAction);

                #region Check Rules Validation

                var validationMessages = Check(inWorkflowAction, inDataModel, inRelatedObjectsForCheckingRules, false);

                var validationMessageDataObjects = validationMessages as IList<IValidationMessageDataObject> ?? validationMessages.ToList();

                if (validationMessageDataObjects.Any())
                {
                    ExceptionFactory.GetNewModelValidationException(validationMessageDataObjects);
                }

                #endregion

                // 4- AfterValidation
                ServiceTemplate.AfterValidation(inDataModel, ref inWorkflowAction);

                #region Preparing Entity For Saving

                if (inDataModel.State != DataModelState.Deleted)
                {
                    var workflowPropertyAttribute = GetWorkflowPropertyAttribute();

                    if (workflowPropertyAttribute != null)
                    {
                        var entityId = inDataModel.Id;

                        var entity = Read(e => e.Id == entityId).FirstOrDefault();

                        if (entity == null)
                        {
                            throw ExceptionFactory.GetNewConcurrencyException(null, "Current entity was deleted.");
                        }

                        if (!inDataModel.RowVersion.Equals(entity.RowVersion))
                        {
                            throw ExceptionFactory.GetNewConcurrencyException(null, "Current entity was changed.");
                        }

                        // Set Old Workflow State
                        Assistant.Reflection.SetPropertyValue(inDataModel, workflowPropertyAttribute.WorkflowPropertyName, Assistant.Reflection.GetPropertyValue<object>(entity, workflowPropertyAttribute.WorkflowPropertyName));

                        if (!workflowPropertyAttribute.SaveOtherChanges)
                        {
                            var properties = Assistant.Reflection.GetProperties(inDataModel.GetType());

                            foreach (var propertyInfo in properties.Where(propertyInfo => propertyInfo.Name != "RowVersion"))
                            {
                                Assistant.Reflection.SetPropertyValue(inDataModel, propertyInfo.Name, Assistant.Reflection.GetPropertyValue<object>(entity, propertyInfo.Name));
                            }

                            inDataModel.AcceptChanges();
                        }
                    }
                }

                #endregion

                SetModelState(inDataModel, inWorkflowAction);

                // 5- BeforeSaveToDataBase
                ServiceTemplate.BeforeSaveToDataBase(inDataModel, inWorkflowAction);

                using (var databaseContext = GetNewDatabaseContextInstance(ContextScope))
                {
                    using (var internalTransaction = new TransactionScope())
                    {
                        databaseContext.SaveEntity(inAuthenticationDataObject, inDataModel, inCheckPropertyValueChangingSecurityControl);

                        // 6- GetSecureData
                        var secureDatas = ServiceTemplate.GetSecureDataForAddOrDelete(inAuthenticationDataObject, inDataModel, inWorkflowAction);

                        if (secureDatas != null && secureDatas.Any())
                        {
                            using (var securityContext = new SecurityContext())
                            {
                                // The 'inCheckPropertyValueChangingSecurityControl' argument of the 'SecurityContext.SaveEntity' method does not have 'CheckPropertyValueChangingSecurityControl' attributes. It be caused that the value of this argument was not important. So we decide to use a 'true' value for preventing logical error occurrences in future.
                                securityContext.SaveEntity(inAuthenticationDataObject, secureDatas.AsEnumerable(), true);
                            }
                        }

                        internalTransaction.Complete();
                    }
                }

                // 7- AfterSaveToDataBase
                ServiceTemplate.AfterSaveToDataBase(inDataModel, inWorkflowAction);

                // 8- AfterProcessActionRequest
                ServiceTemplate.AfterProcessActionRequest(inDataModel, inWorkflowAction);

                transaction.Complete();
            }
        }

        #endregion

        #region Public Methods

        public void InitializeDatabaseContextScope(ContextScopeBase inContextScope)
        {
            ContextScope = inContextScope;
        }

        public virtual int Count()
        {
            return Count(model => true);
        }

        public virtual int Count(Expression<Func<TDataModelType, bool>> inPredicate)
        {
            int result;

            using (var databaseContext = GetNewDatabaseContextInstance(ContextScope))
            {
                result = databaseContext.FetchEntity(ServiceTemplate.BeforeDataRetrieve(inPredicate), null).Count();
            }

            return result;
        }

        public virtual TDataModelType CreateEntity()
        {
            TDataModelType result;

            using (var databaseContext = GetNewDatabaseContextInstance(ContextScope))
            {
                result = databaseContext.CreateEntity<TDataModelType>();
            }

            SetModelState(result, WorkflowStateBase.UnSaved);

            result.AcceptChanges();

            result.MarkAsAdded();

            result = ServiceTemplate.AfterModelCreation(result);

            return result;
        }

        public virtual IQueryable<TDataModelType> Read()
        {
            return Read(model => true, string.Empty);
        }

        public virtual IQueryable<TDataModelType> Read(string inIncludedDataModel)
        {
            return Read(model => true, inIncludedDataModel);
        }

        public virtual IQueryable<TDataModelType> Read(IEnumerable<string> inIncludedDataModels)
        {
            return Read(model => true, inIncludedDataModels);
        }

        public virtual IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate)
        {
            return Read(inPredicate, string.Empty);
        }

        public virtual IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate, string inIncludedDataModel)
        {
            return Read(inPredicate,
                string.IsNullOrEmpty(inIncludedDataModel) ? null : new List<string> { inIncludedDataModel });
        }

        public virtual IQueryable<TDataModelType> Read(Expression<Func<TDataModelType, bool>> inPredicate, IEnumerable<string> inIncludedDataModels)
        {
            IQueryable<TDataModelType> result;

            var predicate = ServiceTemplate.BeforeDataRetrieve(inPredicate);

            using (var databaseContext = GetNewDatabaseContextInstance(ContextScope))
            {
                result = databaseContext.FetchEntity(predicate, inIncludedDataModels);
            }

            result = ServiceTemplate.AfterDataRetrieve(result);

            return result;
        }

        public virtual IEnumerable<IValidationMessageDataObject> Check(WorkflowAction inWorkflowAction, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules, bool inCollectAllValidationMessage)
        {
            return RuleChecker.CheckRules(inWorkflowAction, inDataModel, inRelatedObjectsForCheckingRules, inCollectAllValidationMessage);
        }

        public virtual IEnumerable<IValidationMessageDataObject> Check(WorkflowAction inWorkflowAction, TDataModelType inDataModel, bool inCollectAllValidationMessage)
        {
            return Check(inWorkflowAction, inDataModel, null, inCollectAllValidationMessage);
        }

        public virtual void Save(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction, object inRelatedObjectsForCheckingRules)
        {
            Save(inAuthenticationDataObject, inDataModel, inWorkflowAction, true, inRelatedObjectsForCheckingRules);
        }

        public virtual void Save(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, WorkflowAction inWorkflowAction)
        {
            Save(inAuthenticationDataObject, inDataModel, inWorkflowAction, null);
        }

        public virtual void Save(AuthenticationDataObject inAuthenticationDataObject, IList<TDataModelType> inDataModels, WorkflowAction inWorkflowAction)
        {
            using (var transaction = new TransactionScope())
            {
                if (inDataModels != null)
                {
                    foreach (var dataModel in inDataModels)
                    {
                        Save(inAuthenticationDataObject, dataModel, inWorkflowAction);
                    }
                }

                transaction.Complete();
            }
        }

        public void Delete(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules)
        {
            Save(inAuthenticationDataObject, inDataModel, WorkflowActionBase.Delete, inRelatedObjectsForCheckingRules);
        }

        public void Delete(AuthenticationDataObject inAuthenticationDataObject, TDataModelType inDataModel)
        {
            Delete(inAuthenticationDataObject, inDataModel, null);
        }

        public void Delete(AuthenticationDataObject inAuthenticationDataObject, IList<TDataModelType> inDataModels)
        {
            Save(inAuthenticationDataObject, inDataModels, WorkflowActionBase.Delete);
        }

        public virtual IList<WorkflowAction> GetNextActions(WorkflowState inWorkflowState)
        {
            return WorkflowMachine.GetNextActions(inWorkflowState);
        }

        public virtual IList<WorkflowAction> GetNextActions(TDataModelType inDataModel)
        {
            return WorkflowMachine.GetNextActions(GetModelState(inDataModel));
        }

        public WorkflowState ConvertWorkflowState(string inWorkflowState)
        {
            return WorkflowStateBase.Parse<TWorkflowStateType>(inWorkflowState);
        }

        public string ConvertWorkflowState(WorkflowState inWorkflowState)
        {
            return WorkflowStateBase.ToString<TWorkflowStateType>(inWorkflowState);
        }

        public WorkflowAction ConvertWorkflowAction(string inWorkflowAction)
        {
            return WorkflowActionBase.Parse<TWorkflowActionType>(inWorkflowAction);
        }

        public string ConvertWorkflowAction(WorkflowAction inWorkflowAction)
        {
            return WorkflowActionBase.ToString<TWorkflowActionType>(inWorkflowAction);
        }

        #endregion
    }
}