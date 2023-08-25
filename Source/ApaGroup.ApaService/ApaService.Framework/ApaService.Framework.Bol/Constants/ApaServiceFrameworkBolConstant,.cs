using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaService.Framework.Bol.Constants
{
    public class ApaServiceFrameworkBolConstant : ConstantBase
    {
        #region Private Fields

        private static ApaServiceFrameworkBolConstant _Instance;

        #endregion

        #region Internal Properties

        public static ApaServiceFrameworkBolConstant Instance
        {
            get { return _Instance ?? (_Instance = new ApaServiceFrameworkBolConstant()); }
        }

        #endregion

        #region Public Properties

        public string ServiceAssemblyName
        {
            get { return "ApaService.Framework.Bol"; }
        }

        public string ServiceSpecificNamespace
        {
            get { return "Services"; }
        }

        public string ServiceTemplateSpecificNamespace
        {
            get { return "ServiceTemplates"; }
        }

        public string WorkflowActionSpecificNamespace
        {
            get { return "WorkflowMachines"; }
        }

        public string WorkflowStateSpecificNamespace
        {
            get { return "WorkflowMachines"; }
        }

        public string WorkflowMachineSpecificNamespace
        {
            get { return "WorkflowMachines"; }
        }

        public string ValidationRuleSpecificNamespace
        {
            get { return "Validations"; }
        }

        public string DefaultServiceTypeName
        {
            get { return "ApasService`6"; }
        }

        public string DefaultServiceTemplateTypeName
        {
            get { return "ApasServiceTemplate`1"; }
        }

        public string DefaultWorkflowActionTypeName
        {
            get { return "ApasWorkflowAction"; }
        }

        public string DefaultWorkflowStateTypeName
        {
            get { return "ApasWorkflowState"; }
        }

        public string DefaultWorkflowMachineTypeName
        {
            get { return "ApasWorkflowMachine"; }
        }

        public string DefaultValidationRuleTypeName
        {
            get { return "ApasValidationRule`1"; }
        }

        public string DataModelTypeNamePostfix
        {
            get { return "DataModel"; }
        }

        public string ServiceTemplateTypeNamePostfix
        {
            get { return "ServiceTemplate"; }
        }

        public string WorkflowActionTypeNamePostfix
        {
            get { return "WorkflowAction"; }
        }

        public string WorkflowStateTypeNamePostfix
        {
            get { return "WorkflowState"; }
        }

        public string WorkflowMachineTypeNamePostfix
        {
            get { return "WorkflowMachine"; }
        }

        public string ValidationRuleTypeNamePostfix
        {
            get { return "ValidationRule"; }
        }

        #endregion
    }
}
