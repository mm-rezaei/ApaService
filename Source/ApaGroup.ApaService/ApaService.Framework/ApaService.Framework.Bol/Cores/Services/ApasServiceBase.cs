using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Bol.Cores.Services;
using ApaService.Framework.Bol.Cores.ServiceTemplates;
using ApaService.Framework.Bol.Cores.Validations;
using ApaService.Framework.Bol.Cores.WorkflowMachines;
using ApaService.Framework.Dal.Context.Cores.Contexts;
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;
using ApaService.Framework.IBol.Cores.Services;

namespace ApaService.Framework.Bol.Cores.Services
{
    public abstract class ApasServiceBase<
        TConstantType,
        TDatabaseContextConstantType,
        TDatabaseContextType,
        TDataModelType,
        TServiceTemplateType,
        TWorkflowActionType,
        TWorkflowStateType,
        TWorkflowMachineType,
        TValidationRuleType,
        TServiceArgsType>
        : ServiceBase<
        TConstantType,
        TDatabaseContextConstantType,
        TDatabaseContextType,
        TDataModelType,
        TServiceTemplateType,
        TWorkflowActionType,
        TWorkflowStateType,
        TWorkflowMachineType,
        TValidationRuleType,
        TServiceArgsType>, IApasService<TDataModelType>
        where TConstantType : ConstantBase, new()
        where TDatabaseContextConstantType : ConstantBase, new()
        where TDatabaseContextType : ApasContextBase<TDatabaseContextConstantType>, new()
        where TDataModelType : class, IApasDataModel, new()
        where TServiceTemplateType : ApasServiceTemplateBase<TDataModelType>, new()
        where TWorkflowActionType : ApasWorkflowActionBase
        where TWorkflowStateType : ApasWorkflowStateBase
        where TWorkflowMachineType : ApasWorkflowMachineBase, new()
        where TValidationRuleType : ApasValidationRuleBase<TDataModelType>, new()
        where TServiceArgsType : IApasServiceArgs
    {
        #region Constructors

        protected ApasServiceBase(TServiceArgsType inServiceArgs, ApasContextScopeBase inContextScope)
            : base(inServiceArgs, inContextScope)
        {

        }

        #endregion
    }
}
