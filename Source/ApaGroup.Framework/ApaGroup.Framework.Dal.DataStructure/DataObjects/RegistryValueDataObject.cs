using ApaGroup.Framework.Dal.DataStructure.Cores.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    internal class RegistryValueDataObject : DataObjectBase, IRegistryValueDataObject
    {
        #region Constructors

        internal RegistryValueDataObject(string inRegistryValuePath, RegistryValueType inValueType, string inName,
            object inValue)
        {
            _RegistryValuePath = inRegistryValuePath;
            _ValueType = inValueType;
            _Name = inName;
            Value = inValue;
        }

        #endregion

        #region Private Fields

        private readonly string _Name;

        private readonly string _RegistryValuePath;

        private readonly RegistryValueType _ValueType;

        #endregion

        #region Public Properties

        public string RegistryValuePath
        {
            get { return _RegistryValuePath; }
        }

        public RegistryValueType ValueType
        {
            get { return _ValueType; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public object Value { get; set; }

        #endregion
    }
}