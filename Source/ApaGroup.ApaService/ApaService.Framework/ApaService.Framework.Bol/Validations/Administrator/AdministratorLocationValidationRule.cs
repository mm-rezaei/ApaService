using ApaGroup.Framework.Bol.Attributes;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using ApaService.Framework.Bol.Cores.Validations;
using ApaService.Framework.Bol.Factories.Services;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace ApaService.Framework.Bol.Validations.Administrator
{
    internal class AdministratorLocationValidationRule : ApasValidationRuleBase<AdministratorLocationDataModel>
    {
        #region Public Methods

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckLocationParentId(WorkflowAction inWorkflowAction, AdministratorLocationDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            // this method was checked in 'AdministratorLocationServiceTemplate'.
            return new List<IValidationMessageDataObject>();
        }

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckLocationHirarchyCode(WorkflowAction inWorkflowAction, AdministratorLocationDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            // this method was checked in 'AdministratorLocationServiceTemplate'.
            // Checks Are :
            //      1- The max size of the hirarchy code is 40 characters.
            //      2- The hirarchy code should be compatible with it's paranet and it's siblings.
            return new List<IValidationMessageDataObject>();
        }

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckDublicateLocationTitle(WorkflowAction inWorkflowAction, AdministratorLocationDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            var result = new List<IValidationMessageDataObject>();

            using (var scope = new AdministratorContextScope())
            {
                var service = ServiceFactory.Instance.CreateService<AdministratorLocationDataModel>(scope);

                if (service.Read(location => location.ParentId == inDataModel.ParentId).Count(location => location.Title.ToLower().Replace(" ", "") == inDataModel.Title.ToLower().Replace(" ", "")) != 0)
                {
                    result.Add(GetValidationMessageInstance(inDataModel.Title, "عنوان مکان تکراری می باشد."));
                }
            }

            return result;
        }

        #endregion
    }
}
