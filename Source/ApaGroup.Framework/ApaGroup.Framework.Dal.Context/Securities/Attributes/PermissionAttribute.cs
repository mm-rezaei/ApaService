using ApaGroup.Framework.Basis.Cores.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using System;

namespace ApaGroup.Framework.Dal.Context.Securities.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionAttribute : AttributeBase
    {
        #region Constructors

        public PermissionAttribute(PermissionType inPermissionType)
        {
            Type = inPermissionType;
        }

        #endregion

        #region Public Properties

        public PermissionType Type { get; private set; }

        #endregion
    }
}
