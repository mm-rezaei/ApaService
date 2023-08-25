using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;
using ApaService.Framework.Bol.Cores.ServiceTemplates;
using ApaService.Framework.Bol.Factories.Services;
using ApaService.Framework.Dal.Context.Contexts;
using ApaService.Framework.Dal.DataStructure.DataModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ApaService.Framework.Bol.ServiceTemplates.Administrator
{
    internal class AdministratorLocationServiceTemplate : ApasServiceTemplateBase<AdministratorLocationDataModel>
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

        public override void BeforeProcessActionRequest(AdministratorLocationDataModel inDataModel, ref WorkflowAction inWorkflowAction)
        {
            using (var scope = new AdministratorContextScope())
            {
                var service = ServiceFactory.Instance.CreateService<AdministratorLocationDataModel>(scope);

                // Read Parent Location and Parent Location Hirarchy Code
                var prefixHirarchyCode = @"\";

                if (inDataModel.ParentId != null)
                {
                    var parentLocation = service.Read(location => location.Id == inDataModel.ParentId.Value).FirstOrDefault();

                    if (parentLocation == null)
                    {
                        var messages = new List<IValidationMessageDataObject>
                        {
                            new ValidationMessageDataObject(inDataModel.ParentId.ToString(), "گروه مکانی بالاتر وجود ندارد.")
                        };

                        throw ExceptionFactory.GetNewModelValidationException(messages);
                    }

                    if (parentLocation.HierarchyCode.Length >= SizeOfHirarchyCodeLevelSize * MaxLevelsOfHirarchyCode)
                    {
                        var messages = new List<IValidationMessageDataObject>
                        {
                            new ValidationMessageDataObject(MaxLevelsOfHirarchyCode.ToString(CultureInfo.InvariantCulture), "تعداد سلسله مراتب موجود از حد در نظر گرفته شده بیشتر می باشد.")
                        };

                        throw ExceptionFactory.GetNewModelValidationException(messages);
                    }

                    prefixHirarchyCode = parentLocation.HierarchyCode + @"\";
                }

                // Set Location Hirarchy Code
                var lastHirarchyCodeLocation =
                    service.Read(location => location.ParentId == inDataModel.ParentId)
                    .OrderByDescending(location => location.HierarchyCode)
                    .FirstOrDefault();

                if (lastHirarchyCodeLocation == null)
                {
                    inDataModel.HierarchyCode = prefixHirarchyCode;
                }
                else
                {
                    inDataModel.HierarchyCode = prefixHirarchyCode +
                                                GetNextHirarchyCode(
                                                    lastHirarchyCodeLocation.HierarchyCode.Substring(
                                                        lastHirarchyCodeLocation.HierarchyCode.Length -
                                                        SizeOfHirarchyCodeLevelSize + 1, 3));
                }
            }
        }

        #endregion
    }
}
