using System.Collections.Generic;
using System.Linq;
using ApaGroup.Framework.Bol.Attributes;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using ApaService.Framework.Bol.Cores.Validations;
using ApaService.Framework.Bol.Factories.Services;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;

namespace ApaService.Framework.Bol.Validations.Administrator
{
    internal class AdministratorCategoryValidationRule : ApasValidationRuleBase<AdministratorCategoryDataModel>
    {
        #region Public Methods

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckCategoryParentId(WorkflowAction inWorkflowAction, AdministratorCategoryDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            // this method was checked in 'AdministratorCategoryServiceTemplate'.
            return new List<IValidationMessageDataObject>();
        }

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckCategoryHirarchyCode(WorkflowAction inWorkflowAction, AdministratorCategoryDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            // this method was checked in 'AdministratorCategoryServiceTemplate'.
            // Checks Are :
            //      1- The max size of the hirarchy code is 40 characters.
            //      2- The hirarchy code should be compatible with it's paranet and it's siblings.
            return new List<IValidationMessageDataObject>();
        }

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckDublicateCategoryTitle(WorkflowAction inWorkflowAction, AdministratorCategoryDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            var result = new List<IValidationMessageDataObject>();

            using (var scope = new AdministratorContextScope())
            {
                var service = ServiceFactory.Instance.CreateService<AdministratorCategoryDataModel>(scope);

                if (service.Read(category => category.ParentId == inDataModel.ParentId).Count(category => category.Title.ToLower().Replace(" ", "") == inDataModel.Title.ToLower().Replace(" ", "")) != 0)
                {
                    result.Add(GetValidationMessageInstance(inDataModel.Title, "عنوان گروه تکراری می باشد."));
                }
            }

            return result;
        }

        #endregion
    }
}
