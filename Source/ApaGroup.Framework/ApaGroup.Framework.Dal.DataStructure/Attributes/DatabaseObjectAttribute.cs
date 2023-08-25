using ApaGroup.Framework.Basis.Cores.Attributes;
using System;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DatabaseObjectAttribute : AttributeBase
    {
        #region Constructors

        public DatabaseObjectAttribute(string inDatabaseObject)
        {
            DatabaseObject = inDatabaseObject;
        }

        #endregion

        #region Public Properties

        public string DatabaseObject { get; private set; }

        #endregion
    }
}
