using ApaGroup.Framework.Basis.Cores.Attributes;
using System;

namespace ApaGroup.Framework.Dal.DataStructure.Securities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class SecureIdAttribute : AttributeBase
    {
        #region Constructors

        public SecureIdAttribute(string inDatabaseObject)
        {
            DatabaseObject = inDatabaseObject;
        }

        #endregion

        #region Public Properties

        public string DatabaseObject { get; private set; }

        #endregion
    }
}
