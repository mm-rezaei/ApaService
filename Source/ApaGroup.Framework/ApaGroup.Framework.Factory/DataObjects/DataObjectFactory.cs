using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.InternalFactory;

namespace ApaGroup.Framework.Factory.DataObjects
{
    public class DataObjectFactory
    {
        #region Constructors

        private DataObjectFactory()
        {
        }

        #endregion

        #region Private  Fields

        private static readonly DataObjectFactory _Instance = new DataObjectFactory();

        #endregion

        #region Public Properties

        public static DataObjectFactory Instance
        {
            get { return _Instance; }
        }

        #endregion

        #region Public Methods

        public IRegistryKeyDataObject GetNewRegistryKeyDataObject(string inRegistryValuePath, string inName)
        {
            return DataObjectInternalFactory.GetNewRegistryKeyDataObject(inRegistryValuePath, inName);
        }

        public IRegistryValueDataObject GetNewRegistryValueDataObject(string inRegistryValuePath, string inName, object inValue)
        {
            return DataObjectInternalFactory.GetNewRegistryValueDataObject(inRegistryValuePath, inName, inValue);
        }

        #endregion
    }
}
