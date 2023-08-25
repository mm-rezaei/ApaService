using System;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class RangeValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Constructors

        public RangeValidationRuleAttribute(int inMinimum, int inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;
            Type = typeof (int);
        }

        public RangeValidationRuleAttribute(float inMinimum, float inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;
            Type = typeof (float);
        }

        public RangeValidationRuleAttribute(double inMinimum, double inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;
            Type = typeof (double);
        }

        public RangeValidationRuleAttribute(byte inMinimum, byte inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;
            Type = typeof(byte);
        }

        #endregion

        #region Private Properties

        private object Minimum { get; set; }

        private object Maximum { get; set; }

        private Type Type { get; set; }

        #endregion

        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result = false;

            if (Type == typeof(byte) || Type == typeof (int) || Type == typeof (float) || Type == typeof (double))
            {
                result = true;

                if (Type == typeof(byte))
                {
                    var minimum = ConvertorHelper.ToByte(Minimum);
                    var maximum = ConvertorHelper.ToByte(Maximum);
                    var value = ConvertorHelper.ToByte(inObject);

                    if (value < minimum || value > maximum)
                    {
                        result = false;
                    }
                }
                else if (Type == typeof (int))
                {
                    var minimum = ConvertorHelper.ToInt32(Minimum);
                    var maximum = ConvertorHelper.ToInt32(Maximum);
                    var value = ConvertorHelper.ToInt32(inObject);

                    if (value < minimum || value > maximum)
                    {
                        result = false;
                    }
                }
                else if (Type == typeof (float))
                {
                    var minimum = ConvertorHelper.ToFloat(Minimum);
                    var maximum = ConvertorHelper.ToFloat(Maximum);
                    var value = ConvertorHelper.ToFloat(inObject);

                    if (value < minimum || value > maximum)
                    {
                        result = false;
                    }
                }
                else if (Type == typeof (double))
                {
                    var minimum = ConvertorHelper.ToDouble(Minimum);
                    var maximum = ConvertorHelper.ToDouble(Maximum);
                    var value = ConvertorHelper.ToDouble(inObject);

                    if (value < minimum || value > maximum)
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