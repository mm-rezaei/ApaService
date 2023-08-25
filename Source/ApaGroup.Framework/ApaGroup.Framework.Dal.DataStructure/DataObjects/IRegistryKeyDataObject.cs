using ApaGroup.Framework.Dal.DataStructure.Cores.DataObjects;

namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    public interface IRegistryKeyDataObject : IDataObject
    {
        #region Public Properties

        string RegistryKeyPath { get; }

        string Name { get; }

        #endregion
    }
}