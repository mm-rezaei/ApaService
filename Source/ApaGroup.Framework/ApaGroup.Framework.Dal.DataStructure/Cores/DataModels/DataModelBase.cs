
namespace ApaGroup.Framework.Dal.DataStructure.Cores.DataModels
{
    public abstract class DataModelBase : DataModelChangeTrackerBase, IDataModel
    {
        #region Public Properties

        public abstract int Id { get; set; }

        public abstract byte[] RowVersion { get; set; }

        #endregion
    }
}
