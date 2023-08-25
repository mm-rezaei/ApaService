using System.Collections.Generic;
using ApaGroup.Framework.Bol.Attributes;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using ApaService.Framework.Bol.Cores.Validations;
using ApaService.Framework.Bol.Factories.Services;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;

namespace ApaService.Framework.Bol.Validations.Administrator
{
    internal class AdministratorBrandValidationRule : ApasValidationRuleBase<AdministratorBrandDataModel>
    {
        #region Public Methods

        [ValidationRuleCheck(WorkflowAction.Save)]
        public IList<IValidationMessageDataObject> CheckDublicateBrandTitle(WorkflowAction inWorkflowAction, AdministratorBrandDataModel inDataModel, object inRelatedObjectsForCheckingRules)
        {
            var result = new List<IValidationMessageDataObject>();

            using (var scope = new AdministratorContextScope())
            {
                var service = ServiceFactory.Instance.CreateService<AdministratorBrandDataModel>(scope);

                if(service.Count(brand=> brand.Title.ToLower().Replace(" ","") == inDataModel.Title.ToLower().Replace(" ","")) != 0)
                {
                    result.Add(GetValidationMessageInstance(inDataModel.Title,"عنوان برند تکراری می باشد."));
                }
            }

            return result;
        }

        #endregion
    }
}
