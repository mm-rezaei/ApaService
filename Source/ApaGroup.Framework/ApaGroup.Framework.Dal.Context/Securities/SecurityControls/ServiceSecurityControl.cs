using ApaGroup.Framework.Basis.Cores.Caches;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.Context.Constants;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level2)]
    internal sealed class ServiceSecurityControl : SecurityControlBase
    {
        #region Constructors

        static ServiceSecurityControl()
        {
            CacheManagement.Instance.RegisterCache(UsersAccessHistoriesCacheKey);
        }

        private ServiceSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private ConcurrentDictionary<string, UserAccessHistory> _UsersAccessHistories = new ConcurrentDictionary<string, UserAccessHistory>(10, int.MaxValue);

        private static readonly ServiceSecurityControl _Instance = new ServiceSecurityControl();

        #endregion

        #region Private Properties

        private static string UsersAccessHistoriesCacheKey
        {
            get
            {
                return ApaGroupFrameworkDalContextConstant.Instance.UsersAccessHistoriesCacheKey;
            }
        }

        private ConcurrentDictionary<string, UserAccessHistory> UsersAccessHistories
        {
            get { return _UsersAccessHistories; }
            set { _UsersAccessHistories = value; }
        }

        private int Interval
        {
            get { return 5; }
        }

        int? TotalAccessCount
        {
            get { return 500; }
        }

        int InvalidAccessCount
        {
            get { return 5; }
        }

        #endregion

        #region Private Class

        private class UserAccessHistory
        {
            #region Constructors

            /// <summary>
            /// 
            /// </summary>
            /// <param name="inInterval">The minutes count of checked period</param>
            /// <param name="inTotalAccessCount">The total access count in interval</param>
            /// <param name="inInvalidAccessCount">The invalid access count in interval</param>
            public UserAccessHistory(int inInterval, int? inTotalAccessCount, int inInvalidAccessCount)
            {
                Interval = inInterval;
                TotalAccessCount = inTotalAccessCount;
                InvalidAccessCount = inInvalidAccessCount;
                AccessList = new List<Tuple<DateTime, bool>>();
            }

            #endregion

            #region Private Properties

            private int Interval { get; set; }

            private int? TotalAccessCount { get; set; }

            private int InvalidAccessCount { get; set; }

            private IList<Tuple<DateTime, bool>> AccessList { get; set; }

            #endregion

            #region Private Methods

            private bool IsDateTimeInRange(DateTime inAccessDateTime, DateTime inCurrentDateTime)
            {
                var result = false;

                var extract = inCurrentDateTime - inAccessDateTime;

                if (extract.Minutes <= Interval)
                {
                    result = true;
                }

                return result;
            }

            #endregion

            #region Public Methods

            public bool AddServiceAccess(bool inAccessStatus)
            {
                var result = true;

                var now = DateTime.Now;

                #region Remove Old Access Log

                for (var index = AccessList.Count - 1; index >= 0; index--)
                {
                    if (!IsDateTimeInRange(AccessList[index].Item1, now))
                    {
                        AccessList.RemoveAt(index);
                    }
                }

                #endregion

                #region Check Total Access Count

                if (TotalAccessCount.HasValue)
                {
                    if (AccessList.Count >= TotalAccessCount.Value)
                    {
                        result = false;
                    }
                }

                #endregion

                #region Check Invalid Access Count

                if (result)
                {
                    var invalidAccessCount = AccessList.Count(access => !access.Item2);

                    if (invalidAccessCount >= InvalidAccessCount)
                    {
                        result = false;
                    }
                }

                #endregion

                if (result)
                {
                    if (TotalAccessCount.HasValue)
                    {
                        AccessList.Add(new Tuple<DateTime, bool>(now, inAccessStatus));
                    }
                    else if (!TotalAccessCount.HasValue && !inAccessStatus)
                    {
                        AccessList.Add(new Tuple<DateTime, bool>(now, false));
                    }
                }

                return result;
            }

            #endregion
        }

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- Username 2- inAccessStatus</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var usernameHashCode = inObjects[0].ToString().Replace(" ", "").ToLower();
            var accessStatus = ConvertorHelper.GetCastValue<bool>(inObjects[1]);

            #region Reset UsersAccessHistories Cache

            if (CacheManagement.Instance.IsNeededInitialization(UsersAccessHistoriesCacheKey))
            {
                lock (this)
                {
                    if (CacheManagement.Instance.IsNeededInitialization(UsersAccessHistoriesCacheKey))
                    {
                        UsersAccessHistories = new ConcurrentDictionary<string, UserAccessHistory>(10, int.MaxValue);

                        CacheManagement.Instance.ResetInitializationFlag(UsersAccessHistoriesCacheKey);
                    }
                }
            }

            #endregion

            UserAccessHistory currentUserAccessHistory;

            if (UsersAccessHistories.ContainsKey(usernameHashCode))
            {
                currentUserAccessHistory = UsersAccessHistories[usernameHashCode];
            }
            else
            {
                currentUserAccessHistory = new UserAccessHistory(Interval, TotalAccessCount, InvalidAccessCount);

                if (!UsersAccessHistories.TryAdd(usernameHashCode, currentUserAccessHistory))
                {
                    throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.ServiceLimited.ToString());
                }
            }

            if (!currentUserAccessHistory.AddServiceAccess(accessStatus))
            {
                throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.ServiceLimited.ToString());
            }
        }

        #endregion

        #region Public Properties

        public static ServiceSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
