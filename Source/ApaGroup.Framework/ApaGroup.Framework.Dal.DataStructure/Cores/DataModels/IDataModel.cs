
namespace ApaGroup.Framework.Dal.DataStructure.Cores.DataModels
{
    public interface IDataModel : IDataModelChangeTracker
    {
        #region Public Properties

        int Id { get; set; }

        byte[] RowVersion { get; set; }

        #endregion
    }
}