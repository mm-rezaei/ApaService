using System;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class StringLengthValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Constructors

        public StringLengthValidationRuleAttribute(int inLength)
        {
            Length = inLength;
        }

        #endregion

        #region Private Properties

        private int Length { get; set; }

        #endregion

        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result = true;

            var value = inObject as string;

            if (value == null)
            {
                throw ExceptionFactory.GetNewTypeConversionException(
                    new NullReferenceException("Validation object is not string type."));
            }

            if (value.Length > Length)
            {
                result = false;
            }

            return result;
        }

        #endregion
    }
}