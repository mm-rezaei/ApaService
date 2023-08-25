using System;
using ApaGroup.Framework.Basis.Cores.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.Securities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValueChangePreventerAttribute : AttributeBase
    {
        #region Constructors

        public ValueChangePreventerAttribute(AccountType inAppliedAccountTypes)
        {
            AppliedAccountTypes = inAppliedAccountTypes;
        }

        #endregion

        #region Public Properties

        public AccountType AppliedAccountTypes { get; private set; }

        #endregion
    }
}
