using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Exceptions;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.Context.Extensions;
using ApaGroup.Framework.Dal.Context.Securities.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;

namespace ApaGroup.Framework.Dal.Context.Cores.Contexts
{
    public abstract class DatabaseContextBase<TConstantType> : ContextBase<TConstantType>, IDisposable
        where TConstantType : ConstantBase, new()
    {
        #region Constructors

        ~DatabaseContextBase()
        {
            Dispose();
        }

        #endregion

        #region Private Fields

        private static readonly ConcurrentDictionary<Type, Type> _DataModelsMasterParent = new ConcurrentDictionary<Type, Type>(10, 5000);

        private readonly ConcurrentDictionary<Type, Dictionary<string, object>> _DefaultValue = new ConcurrentDictionary<Type, Dictionary<string, object>>(10, 5000);

        #endregion

        #region Private Properties

        private static ConcurrentDictionary<Type, Type> DataModelsMasterParent
        {
            get { return _DataModelsMasterParent; }
        }

        private ConcurrentDictionary<Type, Dictionary<string, object>> DefaultValue
        {
            get { return _DefaultValue; }
        }

        private ContextScopeBase ContextScope { get; set; }

        #endregion

        #region Private Methods

        private Dictionary<string, object> GetDefaultValue(Type inDataModelType)
        {
            if (!DefaultValue.ContainsKey(inDataModelType))
            {
                lock (this)
                {
                    if (!DefaultValue.ContainsKey(inDataModelType))
                    {
                        #region Fill Properties Default Value Dictionary

                        var propertiesInformation =
                            Assistant.Reflection.GetProperties(inDataModelType)
                                .Where(
                                    property =>
                                        Assistant.Reflection.GetCustomAttributes<PropertyDefaultValueAttribute>(
                                            property,
                                            true).Any())
                                .Select(
                                    property =>
                                        new
                                        {
                                            property.Name,
                                            Assistant.Reflection.GetCustomAttributes<PropertyDefaultValueAttribute>(
                                                property, true).First().DefaultValue
                                        }).ToList();

                        var propertiesDefaultValue = propertiesInformation.ToDictionary(
                            information => information.Name, information => information.DefaultValue);

                        #endregion

                        if (!DefaultValue.TryAdd(inDataModelType, propertiesDefaultValue))
                        {
                            throw ExceptionFactory.GetNewFactoryException(null,
                                "The properties default value of '" + inDataModelType +
                                "' could not add to the properties default value cache.");
                        }
                    }
                }
            }

            return DefaultValue[inDataModelType];
        }

        private void SetDefaultValue<TEntityType>(TEntityType inEntity) where TEntityType : class, IDataModel
        {
            var defaultValues = GetDefaultValue(typeof(TEntityType));

            foreach (var property in defaultValues)
            {
                Assistant.Reflection.SetPropertyValue(inEntity, property.Key, property.Value);
            }
        }

        #endregion

        #region Protected Properties

        protected virtual bool FreshDataFetchingEnable
        {
            get { return false; }
        }

        protected ObjectContext Context
        {
            get { return ((IObjectContextAdapter)ContextScope.ContextInstance).ObjectContext; }
        }

        #endregion

        #region Protected Methods

        protected virtual IQueryable<TEntityType> AddSpecialPredicate<TEntityType>(
            IQueryable<TEntityType> inQueryable) where TEntityType : class
        {
            return inQueryable;
        }

        protected Type GetDataModelMasterParent(Type inDataModelType)
        {
            var result = inDataModelType;

            if (DataModelsMasterParent.ContainsKey(inDataModelType))
            {
                result = DataModelsMasterParent[inDataModelType];
            }
            else
            {
                while (result != null && result.BaseType != typeof(object))
                {
                    var dataModelAttribute =
                        Assistant.Reflection.GetCustomAttributes<DataModelAttribute>(inDataModelType, false)
                            .FirstOrDefault();

                    if (dataModelAttribute != null)
                    {
                        result = result.BaseType;
                    }
                }

                DataModelsMasterParent.TryAdd(inDataModelType, result);
            }

            return result;
        }

        #endregion

        #region Public Methods

        public virtual void Dispose()
        {

        }

        public void InitializeDatabaseContextScope(ContextScopeBase inContextScope)
        {
            ContextScope = inContextScope;
        }

        public TEntityType CreateEntity<TEntityType>() where TEntityType : class, IDataModel
        {
            var result = Context.CreateObject<TEntityType>();

            SetDefaultValue(result);

            return result;
        }

        public IQueryable<TEntityType> FetchEntity<TEntityType>(IEnumerable<string> inIncludedDataModels) where TEntityType : class, IDataModel
        {
            Expression<Func<TEntityType, bool>> fetchAll = entity => true;

            return FetchEntity(fetchAll, inIncludedDataModels);
        }

        public IQueryable<TEntityType> FetchEntity<TEntityType>(Expression<Func<TEntityType, bool>> inPredicate) where TEntityType : class, IDataModel
        {
            return FetchEntity(inPredicate, null);
        }

        public IQueryable<TEntityType> FetchEntity<TEntityType>(Expression<Func<TEntityType, bool>> inPredicate, IEnumerable<string> inIncludedDataModels) where TEntityType : class, IDataModel
        {
            IQueryable<TEntityType> result;

            try
            {
                ObjectQuery<TEntityType> objectSet = Context.CreateObjectSet<TEntityType>();

                if (inIncludedDataModels != null)
                {
                    objectSet = inIncludedDataModels.Aggregate(objectSet,
                        (current, includedDataModel) => current.Include(includedDataModel));
                }

                result = AddSpecialPredicate(objectSet).Where(inPredicate).AsQueryable().AsNoTracking();

                if (FreshDataFetchingEnable)
                {
                    Context.Refresh(RefreshMode.StoreWins, result);
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewDatabaseException(ex);
            }

            return result;
        }

        public void SaveEntity<TEntityType>(AuthenticationDataObject inAuthenticationDataObject, TEntityType inEntity, bool inCheckPropertyValueChangingSecurityControl) where TEntityType : class, IDataModel
        {
            try
            {
                #region Security Control : DataViewSavingPreventSecurityControl

                SecurityControlHelper.CheckDataViewSavingSecurityControl(inEntity);

                #endregion

                #region Apply Changes : Context.ApplyChanges

                // Detect the master parent of the current entity type, if the current entity was inherited from another one.
                var dataModelMasterParent = GetDataModelMasterParent(typeof(TEntityType));

                // Apply the changes.
                ContextScope.ContextInstance.ApplyChanges(inAuthenticationDataObject, inEntity, dataModelMasterParent, GetDefaultValue(typeof(TEntityType)), inCheckPropertyValueChangingSecurityControl);

                #endregion

                #region Save Changes : Context.SaveChanges()

                Context.SaveChanges();

                #endregion

                #region Accept Changes : inEntity.ChangeTracker.AcceptChanges()

                inEntity.AcceptChanges();

                #endregion
            }
            catch (SecurityControlException)
            {
                throw;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ExceptionFactory.GetNewConcurrencyException(ex);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewDatabaseException(ex);
            }
            finally
            {
                #region Accept All Changes Of The Context : Context.AcceptAllChanges()

                Context.AcceptAllChanges();

                #endregion

                #region Detach : Context.Detach(inEntity)

                Context.Detach(inEntity);

                #endregion
            }
        }

        public void SaveEntity<TEntityType>(AuthenticationDataObject inAuthenticationDataObject, IEnumerable<TEntityType> inEntities, bool inCheckPropertyValueChangingSecurityControl) where TEntityType : class, IDataModel
        {
            using (var transaction = new TransactionScope())
            {
                foreach (var entity in inEntities)
                {
                    SaveEntity(inAuthenticationDataObject, entity, inCheckPropertyValueChangingSecurityControl);
                }

                transaction.Complete();
            }
        }

        #endregion
    }
}