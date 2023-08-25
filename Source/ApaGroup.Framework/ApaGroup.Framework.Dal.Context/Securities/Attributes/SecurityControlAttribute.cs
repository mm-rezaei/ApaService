using System;
using ApaGroup.Framework.Basis.Cores.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;

namespace ApaGroup.Framework.Dal.Context.Securities.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class SecurityControlAttribute : AttributeBase
    {
        #region Constructors

        public SecurityControlAttribute(SecurityControlLevelNumber inLevelNumber)
        {
            LevelNumber = inLevelNumber;
        }

        #endregion

        #region Public Properties

        public SecurityControlLevelNumber LevelNumber { get; private set; }

        #endregion
    }
}
