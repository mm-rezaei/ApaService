using System.Collections.Concurrent;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;
using ApaGroup.Framework.Basis.Factory;

namespace ApaGroup.Framework.Basis.Cores.Caches
{
    public sealed class CacheManagement : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Private Fields

        private static readonly CacheManagement _Instance = new CacheManagement();

        private readonly ConcurrentDictionary<string, bool> _CacheValues = new ConcurrentDictionary<string, bool>(10, 5000);

        #endregion

        #region Private Properties

        private ConcurrentDictionary<string, bool> CacheValues
        {
            get
            {
                return _CacheValues;
            }
        }

        private bool this[string inKey]
        {
            get
            {
                bool result;

                var key = GetNormalizedKey(inKey);

                if (CacheValues.ContainsKey(key))
                {
                    result = CacheValues[key];
                }
                else
                {
                    throw ExceptionFactory.GetNewCacheException("The cache key does not exist.");
                }

                return result;
            }
            set
            {
                lock (this)
                {
                    var key = GetNormalizedKey(inKey);

                    if (CacheValues.ContainsKey(key))
                    {
                        CacheValues[key] = value;
                    }
                    else
                    {
                        throw ExceptionFactory.GetNewCacheException("The cache key does not exist.");
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private string GetNormalizedKey(string inKey)
        {
            var result = inKey.ToLower().Trim().Replace(" ", "");

            return result;
        }

        #endregion

        #region Public Properties

        public static CacheManagement Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region Public Methods

        public void RegisterCache(string inKey)
        {
            lock (this)
            {
                var key = GetNormalizedKey(inKey);

                if (!CacheValues.ContainsKey(key))
                {
                    CacheValues[key] = true;
                }
                else
                {
                    throw ExceptionFactory.GetNewCacheException("The cache key exist.");
                }
            }
        }

        public void SetInitializationFlag(string inKey)
        {
            this[inKey] = true;
        }

        public void ResetInitializationFlag(string inKey)
        {
            this[inKey] = false;
        }

        public bool IsNeededInitialization(string inKey)
        {
            return this[inKey];
        }

        public void Clear()
        {
            lock (this)
            {
                CacheValues.Clear();
            }
        }

        #endregion
    }
}