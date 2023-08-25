using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.InternalFactory
{
    public static class DataObjectInternalFactory
    {
        #region Public Methods

        public static IRegistryKeyDataObject GetNewRegistryKeyDataObject(string inRegistryValuePath, string inName)
        {
            var result = new RegistryKeyDataObject(inRegistryValuePath, inName);

            return result;
        }

        public static IRegistryValueDataObject GetNewRegistryValueDataObject(string inRegistryValuePath, string inName, object inValue)
        {
            var result = new RegistryValueDataObject(inRegistryValuePath, RegistryValueType.String, inName, inValue);

            return result;
        }

        #endregion
    }
}
