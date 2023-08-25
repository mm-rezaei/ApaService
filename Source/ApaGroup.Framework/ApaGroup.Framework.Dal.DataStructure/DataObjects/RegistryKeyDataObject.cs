using ApaGroup.Framework.Dal.DataStructure.Cores.DataObjects;

namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    internal class RegistryKeyDataObject : DataObjectBase, IRegistryKeyDataObject
    {
        #region Constructors

        internal RegistryKeyDataObject(string inRegistryValuePath, string inName)
        {
            _RegistryKeyPath = inRegistryValuePath;
            _Name = inName;
        }

        #endregion

        #region Private Fields

        private readonly string _Name;

        private readonly string _RegistryKeyPath;

        #endregion

        #region Public Properties

        public string RegistryKeyPath
        {
            get { return _RegistryKeyPath; }
        }

        public string Name
        {
            get { return _Name; }
        }

        #endregion
    }
}