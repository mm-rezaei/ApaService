using ApaGroup.Framework.Basis.Cores.Attributes;
using System;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class PropertyDefaultValueAttribute : AttributeBase
    {
        #region Constructors

        public PropertyDefaultValueAttribute(object inDefaultValue)
        {
            DefaultValue = inDefaultValue;
        }

        #endregion

        #region Public Properties

        public object DefaultValue { get; private set; }

        #endregion
    }
}
