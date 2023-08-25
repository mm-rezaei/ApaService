
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Basis.Locks;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Contexts;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.Context.Securities.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Securities.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level7)]
    internal sealed class SecureDataAccessSecurityControl : SecurityControlBase
    {
        #region Private Fields

        private static readonly InternalLock _InternalLock = new InternalLock();

        private static readonly ConcurrentDictionary<Type, IList<SecureCacheItem>> _SecureAttributeCache = new ConcurrentDictionary<Type, IList<SecureCacheItem>>(10, 5000);

        private static readonly SecureDataAccessSecurityControl _Instance = new SecureDataAccessSecurityControl();

        #endregion

        #region Private Properties

        private static InternalLock InternalLock
        {
            get { return _InternalLock; }
        }

        private static ConcurrentDictionary<Type, IList<SecureCacheItem>> SecureAttributeCache
        {
            get { return _SecureAttributeCache; }
        }

        #endregion

        #region Private Methods

        private static IEnumerable<SecureCacheItem> GetSecureIdItems(Type inDataModelType)
        {
            if (!SecureAttributeCache.ContainsKey(inDataModelType))
            {
                lock (InternalLock)
                {
                    if (!SecureAttributeCache.ContainsKey(inDataModelType))
                    {
                        var list =
                            ReflectionHelper.GetProperties(inDataModelType)
                                .Where(
                                    property =>
                                        ReflectionHelper.GetCustomAttributes<SecureIdAttribute>(property, true).Any())
                                .Select(
                                    property =>
                                        new SecureCacheItem
                                        {
                                            FieldName = property.Name,
                                            TableKey =
                                                DatabaseObjectKeyHelper.GetTableKey(
                                                    ReflectionHelper.GetCustomAttributes<SecureIdAttribute>(property,
                                                        true).First().DatabaseObject)
                                        }).ToList();

                        if (!SecureAttributeCache.TryAdd(inDataModelType, list))
                        {
                            throw ExceptionFactory.GetNewFactoryException(null,
                                "The secure id attributes of '" + inDataModelType +
                                "' could not add to the attributes cache.");
                        }
                    }
                }
            }

            return SecureAttributeCache[inDataModelType];
        }

        #endregion

        #region Private Class

        private class SecureCacheItem
        {
            #region Public Properties

            public short TableKey { get; set; }

            public string FieldName { get; set; }

            #endregion
        }

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- AuthenticationDataObject 2- IDataModel</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var authenticationDataObject = (AuthenticationDataObject)inObjects[0];
            var dataModel = inObjects[1];

            if (!authenticationDataObject.IsAdministratorUser())
            {
                var secureIdsShouldBeCheck = GetSecureIdItems(dataModel.GetType());

                using (var context = new SecurityContext())
                {
                    if ((from secureCacheItem in secureIdsShouldBeCheck
                         let accountId = authenticationDataObject.AccountId
                         let secureId = ReflectionHelper.GetPropertyValue<int>(dataModel, secureCacheItem.FieldName)
                         let tableId = secureCacheItem.TableKey
                         where !context.FetchEntity<SecurityPrivacySecureDataDataModel>(secureData =>
                        secureData.AccountId == accountId &&
                        secureData.SecureId == secureId &&
                        secureData.TableId == tableId).Any()
                         select accountId).Any())
                    {
                        throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.SecureDataAccessDenied.ToString());
                    }
                }
            }
        }

        #endregion

        #region Public Properties

        public static SecureDataAccessSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
