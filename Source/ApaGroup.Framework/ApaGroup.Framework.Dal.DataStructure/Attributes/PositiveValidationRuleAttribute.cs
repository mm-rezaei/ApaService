using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class PositiveValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result = false;

            var type = inObject.GetType();

            if (type == typeof(int) || type == typeof(float) || type == typeof(double))
            {
                result = true;

                if (type == typeof(byte))
                {
                    var value = ConvertorHelper.ToByte(inObject);

                    if (value < 0)
                    {
                        result = false;
                    }
                }
                else if (type == typeof(int))
                {
                    var value = ConvertorHelper.ToInt32(inObject);

                    if (value < 0)
                    {
                        result = false;
                    }
                }
                else if (type == typeof(float))
                {
                    var value = ConvertorHelper.ToFloat(inObject);

                    if (value < 0)
                    {
                        result = false;
                    }
                }
                else if (type == typeof(double))
                {
                    var value = ConvertorHelper.ToDouble(inObject);

                    if (value < 0)
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
