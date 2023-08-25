using ApaGroup.Framework.Bol.Attributes;
using ApaService.Framework.Bol.Constants;
using ApaService.Framework.Bol.Cores.Services;
using ApaService.Framework.Bol.ServiceTemplates.Administrator;
using ApaService.Framework.Bol.Validations.Administrator;
using ApaService.Framework.Bol.WorkflowMachines;
using ApaService.Framework.Dal.Context.Constants;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.Context.Cores.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;

namespace ApaService.Framework.Bol.Services.Administrator
{
    [Service(typeof(AdministratorLocationDataModel))]
    internal class AdministratorLocationService : ApasServiceBase<
        ApaServiceFrameworkBolConstant,
        ApaServiceFrameworkDalContextConstant,
        ApasContext,
        AdministratorLocationDataModel,
        AdministratorLocationServiceTemplate,
        ApasWorkflowAction,
        ApasWorkflowState,
        ApasWorkflowMachine,
        AdministratorLocationValidationRule,
        ApasServiceArgs>
    {
        #region Constructors

        public AdministratorLocationService(ApasServiceArgs inServiceArgs, ApasContextScopeBase inContextScope)
            : base(inServiceArgs, inContextScope)
        {
        }

        #endregion

        #region Protected Properties

        protected override bool IsAnySaveActionValid
        {
            get { return true; }
        }

        protected override bool IsDeleteActionValid
        {
            get { return false; }
        }

        #endregion

        #region Protected Methods

        protected override void InitializeFromServiceArgs(ApasServiceArgs inServiceArgs)
        {

        }

        #endregion
    }
}
