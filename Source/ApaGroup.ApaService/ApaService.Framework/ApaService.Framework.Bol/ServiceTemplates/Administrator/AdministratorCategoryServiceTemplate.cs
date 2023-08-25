using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using ApaService.Framework.Bol.Cores.ServiceTemplates;
using ApaService.Framework.Bol.Factories.Services;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;

namespace ApaService.Framework.Bol.ServiceTemplates.Administrator
{
    internal class AdministratorCategoryServiceTemplate : ApasServiceTemplateBase<AdministratorCategoryDataModel>
    {
        #region Private Properties

        private int SizeOfHirarchyCodeLevelSize
        {
            get
            {
                // With '\' ("\AAA")
                return 4;
            }
        }

        private int MaxLevelsOfHirarchyCode
        {
            get { return 10; }
        }

        #endregion

        #region Private Methods

        private string GetNextHirarchyCode(string inHirarchyCode)
        {
            var charArray = inHirarchyCode.ToUpper().Trim().ToCharArray();

            for (var index = charArray.Length - 1; index >= 0; index--)
            {
                if (charArray[index] == 'Z')
                {
                    charArray[index] = 'A';

                    if (index != 0)
                    {
                        charArray[index - 1]++;
                    }
                    else
                    {
                        var messages = new List<IValidationMessageDataObject>
                        {
                            new ValidationMessageDataObject(inHirarchyCode, "به علت پر شدن سطح مورد نظر، امکان افزودن زیرمجموعه به این سطح امکان پذیر نمی باشد.")
                        };

                        throw ExceptionFactory.GetNewModelValidationException(messages);
                    }
                }
                else
                {
                    charArray[index]++;   
                }
            }

            return charArray.Aggregate("", (current, node) => current + node.ToString(CultureInfo.InvariantCulture));
        }

        #endregion

        #region Public Methods

        public override void BeforeProcessActionRequest(AdministratorCategoryDataModel inDataModel, ref WorkflowAction inWorkflowAction)
        {
            using (var scope = new AdministratorContextScope())
            {
                var service = ServiceFactory.Instance.CreateService<AdministratorCategoryDataModel>(scope);

                // Read Parent Category and Parent Category Hirarchy Code
                var prefixHirarchyCode = @"\";

                if (inDataModel.ParentId != null)
                {
                    var parentCategory = service.Read(category => category.Id == inDataModel.ParentId.Value).FirstOrDefault();

                    if (parentCategory == null)
                    {
                        var messages = new List<IValidationMessageDataObject>
                        {
                            new ValidationMessageDataObject(inDataModel.ParentId.ToString(), "گروه بالاتر وجود ندارد.")
                        };

                        throw ExceptionFactory.GetNewModelValidationException(messages);
                    }

                    if (parentCategory.HierarchyCode.Length >= SizeOfHirarchyCodeLevelSize*MaxLevelsOfHirarchyCode)
                    {
                        var messages = new List<IValidationMessageDataObject>
                        {
                            new ValidationMessageDataObject(MaxLevelsOfHirarchyCode.ToString(CultureInfo.InvariantCulture), "تعداد سلسله مراتب موجود از حد در نظر گرفته شده بیشتر می باشد.")
                        };

                        throw ExceptionFactory.GetNewModelValidationException(messages);
                    }

                    prefixHirarchyCode = parentCategory.HierarchyCode + @"\";
                }

                // Set Category Hirarchy Code
                var lastHirarchyCodeCategory =
                    service.Read(category => category.ParentId == inDataModel.ParentId)
                    .OrderByDescending(category => category.HierarchyCode)
                    .FirstOrDefault();

                if (lastHirarchyCodeCategory == null)
                {
                    inDataModel.HierarchyCode = prefixHirarchyCode;
                }
                else
                {
                    inDataModel.HierarchyCode = prefixHirarchyCode +
                                                GetNextHirarchyCode(
                                                    lastHirarchyCodeCategory.HierarchyCode.Substring(
                                                        lastHirarchyCodeCategory.HierarchyCode.Length -
                                                        SizeOfHirarchyCodeLevelSize + 1, 3));
                }
            }
        }

        #endregion
    }
}
