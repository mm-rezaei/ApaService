using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;

namespace ApaGroup.Framework.Bol.Cores.Validations
{
    public abstract class ValidationRuleBase<TDataModelType> : ApaGroupBase<ApaGroupFrameworkBasisConstant>
        where TDataModelType : IDataModel
    {
        #region Protected Methods

        protected IValidationMessageDataObject GetValidationMessageInstance(string inTag, string inMessage)
        {
            IValidationMessageDataObject result = new ValidationMessageDataObject(inTag, inMessage);

            return result;
        }

        #endregion

        #region Public Methods

        internal IList<IValidationMessageDataObject> CheckSpecialRules(TDataModelType inDataModel, bool inCollectAllValidationMessage)
        {
            return new List<IValidationMessageDataObject>();
        }

        internal IList<IValidationMessageDataObject> CheckPropertiesRules(TDataModelType inDataModel, bool inCollectAllValidationMessage)
        {
            var result = new List<IValidationMessageDataObject>();

            foreach (var propertyInfo in Assistant.Reflection.GetProperties<TDataModelType>(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
            {
                var attribute = Assistant.Reflection.GetCustomAttributes<ValidationRuleAttributeBase>(propertyInfo, true).SingleOrDefault();

                if (attribute != null)
                {
                    var rule = Assistant.Convertion.GetCastValue<ValidationRuleAttributeBase>(attribute);
                    var property = Assistant.Reflection.GetPropertyValue<object>(inDataModel, propertyInfo.Name);
                    if (!rule.IsValid(property)) result.Add(GetValidationMessageInstance(propertyInfo.Name, rule.Message));
                }

                if (!inCollectAllValidationMessage)
                {
                    if (result.Count > 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}