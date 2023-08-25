using ApaGroup.Framework.Basis.Cores.Attributes;
using System;

namespace ApaGroup.Framework.Bol.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ServiceAttribute : AttributeBase
    {
        #region Public Constructors

        public ServiceAttribute(Type inDataModelType)
        {
            DataModelType = inDataModelType;
        }

        #endregion

        #region Public Properties

        public Type DataModelType { get; private set; }

        #endregion
    }
}
