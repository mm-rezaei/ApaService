using ApaGroup.Framework.Basis.Cores.Helpers;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Locks;
using ApaGroup.Framework.Dal.Context.Constants;
using ApaGroup.Framework.Dal.DataStructure.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.Helpers
{
    public class DatabaseObjectKeyHelper : HelperBase<ApaGroupFrameworkDalContextConstant>
    {
        #region Constructors

        static DatabaseObjectKeyHelper()
        {
            InternalLock = new InternalLock();

            TableKeys = new Dictionary<string, short>
            {
                {"Account".ToLower().Trim(), 1},
                {"AccountAdministrator".ToLower().Trim(), 2},
                {"AccountBuyer".ToLower().Trim(), 3},
                {"AccountRequirement".ToLower().Trim(), 4},
                {"AccountSeller".ToLower().Trim(), 5},
                {"AccountTransaction".ToLower().Trim(), 6},
                {"Basket".ToLower().Trim(), 7},
                {"BasketItem".ToLower().Trim(), 8},
                {"BasketTransaction".ToLower().Trim(), 9},
                {"Brand".ToLower().Trim(), 10},
                {"Category".ToLower().Trim(), 11},
                {"Location".ToLower().Trim(), 12},
                {"PrivacyAccountPermission".ToLower().Trim(), 13},
                {"PrivacyAccountPermissionGroup".ToLower().Trim(), 14},
                {"PrivacyGroup".ToLower().Trim(), 15},
                {"PrivacyPermission".ToLower().Trim(), 16},
                {"PrivacyPermissionGroup".ToLower().Trim(), 17},
                {"PrivacySecureData".ToLower().Trim(), 18},
                {"Product".ToLower().Trim(), 19},
                {"ProductCategory".ToLower().Trim(), 20},
                {"ProductComment".ToLower().Trim(), 21},
                {"ProductNumerable".ToLower().Trim(), 22},
                {"ProductRank".ToLower().Trim(), 23},
                {"ProductStatistics".ToLower().Trim(), 24},
                {"Resource".ToLower().Trim(), 25},
                {"Shop".ToLower().Trim(), 26},
                {"ShopCategory".ToLower().Trim(), 27},
                {"ShopComment".ToLower().Trim(), 28},
                {"ShopDeliveryMethod".ToLower().Trim(), 29},
                {"ShopPaymentMethod".ToLower().Trim(), 30},
                {"ShopRank".ToLower().Trim(), 31},
                {"ShopServeLocation".ToLower().Trim(), 32},
                {"ShopStatistics".ToLower().Trim(), 33},
                {"Transaction".ToLower().Trim(), 34},
                {"User".ToLower().Trim(), 35},
                {"UserLogin".ToLower().Trim(), 36},
            };

            TypeKeys = new ConcurrentDictionary<Type, short>();
        }

        #endregion

        #region Private Properties

        private static InternalLock InternalLock { get; set; }

        private static Dictionary<string, short> TableKeys { get; set; }

        private static ConcurrentDictionary<Type, short> TypeKeys { get; set; }

        #endregion

        #region Private Methods

        public static short GetTableKey(string inTableName)
        {
            return TableKeys[inTableName.ToLower().Trim()];
        }

        public static short GetTypeKey(Type inType)
        {
            if (!TypeKeys.ContainsKey(inType))
            {
                lock (InternalLock)
                {
                    if (!TypeKeys.ContainsKey(inType))
                    {
                        var dataObjectAttribute = Assistant.Reflection.GetCustomAttributes<DatabaseObjectAttribute>(inType, false).FirstOrDefault();

                        if (dataObjectAttribute == null)
                        {
                            throw ExceptionFactory.GetNewFactoryException(null, "The 'DatabaseObjectAttribute' object is null.");
                        }

                        if (!TypeKeys.TryAdd(inType, GetTableKey(dataObjectAttribute.DatabaseObject)))
                        {
                            throw ExceptionFactory.GetNewFactoryException(null, "The table key could not add to the cache.");
                        }
                    }
                }
            }

            var result = TypeKeys[inType];

            return result;
        }

        #endregion
    }
}
