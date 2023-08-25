using System.Collections.Generic;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IRegistryAuxiliary : IAuxiliary
    {
        #region Public Methods

        bool ExistsRegistryKey(string inRegistryKeyPath);

        bool ExistsRegistryValue(string inRegistryValuePath);

        IRegistryValueDataObject ReadRegistryValue(string inRegistryValuePath);

        IEnumerable<IRegistryKeyDataObject> ReadAllRegistryKeies(string inRegistryKeyPath);

        IEnumerable<IRegistryValueDataObject> ReadAllRegistryValues(string inRegistryKeyPath);

        void SaveRegistryKey(IRegistryKeyDataObject inRegistryKey);

        void SaveRegistryValue(IRegistryValueDataObject inRegistryValue);

        void DeleteRegistryKey(IRegistryKeyDataObject inRegistryKey);

        void DeleteRegistryValue(IRegistryValueDataObject inRegistryValue);

        void DeleteRegistryKey(IEnumerable<IRegistryKeyDataObject> inRegistryKey);

        void DeleteRegistryValue(IEnumerable<IRegistryValueDataObject> inRegistryValue);

        #endregion
    }
}