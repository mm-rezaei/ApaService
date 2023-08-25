using System;
using ApaGroup.Framework.Basis.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Cores.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class ValidationRuleAttributeBase : AttributeBase
    {
        #region Public Properties

        public virtual string Message { get; set; }

        #endregion

        #region Public Methods

        public abstract bool IsValid(object inObject);

        #endregion
    }
}