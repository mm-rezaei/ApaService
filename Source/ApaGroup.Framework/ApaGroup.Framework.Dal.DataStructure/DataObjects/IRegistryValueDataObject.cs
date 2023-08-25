using ApaGroup.Framework.Dal.DataStructure.Cores.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    public interface IRegistryValueDataObject : IDataObject
    {
        #region Public Properties

        string RegistryValuePath { get; }

        RegistryValueType ValueType { get; }

        string Name { get; }

        object Value { get; set; }

        #endregion
    }
}