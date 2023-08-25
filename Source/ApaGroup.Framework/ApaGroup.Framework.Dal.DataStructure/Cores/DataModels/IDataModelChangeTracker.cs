
using System.ComponentModel;
using ApaGroup.Framework.Dal.DataStructure.Cores.Systems;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.Cores.DataModels
{
    public interface IDataModelChangeTracker : IDataStructure, INotifyPropertyChanged
    {
        #region Public Properties

        DataModelState State { get; }

        bool ChangeTrackingEnabled { get; }

        bool IsAdded { get; }

        bool IsDirty { get; }

        bool IsModified { get; }

        #endregion

        #region Public Methods

        void StartTracking();

        void StopTracking();

        void MarkAsAdded();

        void MarkAsModified();

        void MarkAsDeleted();

        void UnmarkDeleted();

        void AcceptChanges();

        bool IsPropertyModified<TPropertyType>(string inPropertyName, TPropertyType inPropertyValue);

        TPropertyType GetPropertyDefualtValue<TPropertyType>(string inPropertyName, TPropertyType inPropertyValue);

        IDataModelChangeTracker Clone();

        #endregion
    }
}
