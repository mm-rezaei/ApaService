using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class RequiredValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result = true;

            if (inObject == null)
            {
                result = false;
            }
            else
            {
                if (inObject is string)
                {
                    var value = inObject as string;

                    if (string.IsNullOrEmpty(value))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}