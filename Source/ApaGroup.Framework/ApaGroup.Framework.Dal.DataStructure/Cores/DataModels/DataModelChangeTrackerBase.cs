using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;

namespace ApaGroup.Framework.Dal.DataStructure.Cores.DataModels
{
    [DataContract(IsReference = true)]
    public class DataModelChangeTrackerBase : IDataModelChangeTracker
    {
        #region Constructors

        protected DataModelChangeTrackerBase()
        {
            State = DataModelState.Added;

            ModifiedProperties = new Hashtable();

            StartTracking();
        }

        #endregion

        #region Private Properties

        private Hashtable ModifiedProperties { get; set; }

        #endregion

        #region Private Methods

        private void AddNewModifiedPropertyInfo<TPropertyType>(string inSourcePropertyName, TPropertyType inOldValue)
        {
            if (ChangeTrackingEnabled && !String.IsNullOrEmpty(inSourcePropertyName))
            {
                var modifiedPropertyInfo =
                    GetModifiedPropertyInfo<TPropertyType>(inSourcePropertyName);

                if (modifiedPropertyInfo == null)
                {
                    modifiedPropertyInfo = new ModifiedPropertyInformation<TPropertyType>(inSourcePropertyName,
                        inOldValue);
                    ModifiedProperties.Add(inSourcePropertyName.ToUpper(), modifiedPropertyInfo);
                }
            }
        }

        private ModifiedPropertyInformation<TPropertyType> GetModifiedPropertyInfo<TPropertyType>(string inSourcePropertyName)
        {
            return (ModifiedPropertyInformation<TPropertyType>)ModifiedProperties[inSourcePropertyName.ToUpper()];
        }

        #endregion

        #region Protected Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string inPropertyName = null)
        {
            if (State == DataModelState.Unchanged)
            {
                State = DataModelState.Modified;
            }

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(inPropertyName));
            }
        }

        protected void SetValue<TPropertyType>(string inSourcePropertyName, ref TPropertyType refDestination, TPropertyType inNewValue)
        {
            if (ChangeTrackingEnabled)
            {
                var beChange = false;

                if (typeof(TPropertyType).IsValueType)
                {
                    beChange = !inNewValue.Equals(refDestination);
                }
                else
                {
                    object newValue = inNewValue;
                    object destination = refDestination;

                    if (newValue != null && destination != null)
                    {
                        beChange = !inNewValue.Equals(refDestination);
                    }
                    else if (newValue != null)
                    {
                        beChange = !inNewValue.Equals(refDestination);
                    }
                    else if (destination != null)
                    {
                        beChange = !refDestination.Equals(inNewValue);
                    }
                }

                if (beChange)
                {
                    AddNewModifiedPropertyInfo(inSourcePropertyName, refDestination);

                    refDestination = inNewValue;

                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Protected Class

        protected sealed class ModifiedPropertyInformation<TPropertyType>
        {
            #region Constructors

            public ModifiedPropertyInformation(string inSourcePropertyName, TPropertyType inDefaultValue)
            {
                SourcePropertyName = inSourcePropertyName;
                DefaultValue = inDefaultValue;
            }

            #endregion

            #region Public Properties

            public string SourcePropertyName { get; private set; }

            public TPropertyType DefaultValue { get; private set; }

            #endregion
        }

        #endregion

        #region Public Properties

        [DataMember]
        public DataModelState State { get; private set; }

        public bool ChangeTrackingEnabled { get; private set; }

        public bool IsAdded
        {
            get { return (State == DataModelState.Added || State == DataModelState.AddedDeleted); }
        }

        public bool IsDirty
        {
            get{ return (State == DataModelState.Added || State == DataModelState.Modified || State == DataModelState.Deleted); }
        }

        public bool IsModified
        {
            get { return State == DataModelState.Modified; }
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        [OnSerializing]
        public void OnSerializingMethod(StreamingContext inContext)
        {
            StopTracking();
        }

        [OnSerialized]
        public void OnSerializedMethod(StreamingContext inContext)
        {
            StartTracking();
        }

        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext inContext)
        {
            StopTracking();
        }

        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext inContext)
        {
            StartTracking();
        }

        public void StartTracking()
        {
            ChangeTrackingEnabled = true;
        }

        public void StopTracking()
        {
            ChangeTrackingEnabled = false;
        }

        public virtual void MarkAsAdded()
        {
            State = DataModelState.Added;
        }

        public void MarkAsModified()
        {
            OnPropertyChanged();
        }

        public virtual void MarkAsDeleted()
        {
            switch (State)
            {
                case DataModelState.Added:
                    State = DataModelState.AddedDeleted;
                    break;
                case DataModelState.Unchanged:
                case DataModelState.Modified:
                    State = DataModelState.Deleted;
                    break;
            }
        }

        public virtual void UnmarkDeleted()
        {
            switch (State)
            {
                case DataModelState.Deleted:
                    State = DataModelState.Modified;
                    break;
                case DataModelState.AddedDeleted:
                    State = DataModelState.Added;
                    break;
            }
        }

        public void AcceptChanges()
        {
            State = DataModelState.Unchanged;
            ModifiedProperties = new Hashtable();
        }

        public bool IsPropertyModified<TPropertyType>(string inPropertyName, TPropertyType inPropertyValue)
        {
            var result = GetModifiedPropertyInfo<TPropertyType>(inPropertyName) != null;

            return result;
        }

        public TPropertyType GetPropertyDefualtValue<TPropertyType>(string inSourcePropertyName, TPropertyType inPropertyValue)
        {
            var result = default(TPropertyType);

            if (!IsAdded)
            {
                var property =
                    GetModifiedPropertyInfo<TPropertyType>(inSourcePropertyName);

                result = property != null ? property.DefaultValue : inPropertyValue;
            }

            return result;
        }

        public virtual IDataModelChangeTracker Clone()
        {
            return (IDataModelChangeTracker)MemberwiseClone();
        }

        #endregion
    }
}
