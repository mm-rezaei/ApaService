using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Securities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects
{
    public class AuthenticationDataObject : DataObjectBase
    {
        #region Constructors

        public AuthenticationDataObject(string inUserName, byte[] inPassword, int? inAccountId)
        {
            InitializeProperties(GetUserType(inUserName), inUserName, inPassword, inAccountId);
        }

        #endregion

        #region Private Fields

        private int? _UserId;

        #endregion

        #region Private Properties

        private bool ChangingEnable { get; set; }

        private List<int> AccountPermissions { get; set; }

        #endregion

        #region Private Methods

        private void InitializeProperties(UserType inUserType, string inUserName, byte[] inPassword, int? inAccountId)
        {
            StartChanging();

            AuthenticationId = Guid.NewGuid();

            UserType = inUserType;
            UserId = null;
            Username = inUserName.ToLower().Replace(" ", "");
            Password = inPassword;
            AccountId = UserType == UserType.Administrator || UserType == UserType.General ? null : inAccountId;

            StopChanging();
        }

        private UserType GetUserType(string inUsername)
        {
            var result = UserType.None;

            if (String.Equals(inUsername.Replace(" ", ""), UserType.Administrator.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                result = UserType.Administrator;
            }
            else if (String.Equals(inUsername.Replace(" ", ""), UserType.General.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                result = UserType.General;
            }

            return result;
        }

        private void SetAdministratorAndGeneralUserId()
        {
            UserId = -1;
        }

        #endregion

        #region Public Properties

        public Guid AuthenticationId { get; private set; }

        public UserType UserType { get; private set; }

        public string Username { get; private set; }

        public byte[] Password { get; private set; }

        public int? UserId
        {
            get { return _UserId; }
            private set
            {
                if (ChangingEnable)
                {
                    _UserId = value;
                }
                else
                {
                    throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
                }
            }
        }

        public int? AccountId { get; private set; }

        #endregion

        #region Public Methods

        public void StartChanging()
        {
            ChangingEnable = true;
        }

        public void StopChanging()
        {
            ChangingEnable = false;
        }

        public bool IsAdministratorUser()
        {
            return UserType == UserType.Administrator;
        }

        public bool IsGeneralUser()
        {
            return UserType == UserType.General;
        }

        public bool IsAdminAccessLevel()
        {
            return UserType == UserType.AdminAccessLevel;
        }

        public bool IsBuyerAccessLevel()
        {
            return UserType == UserType.BuyerAccessLevel;
        }

        public bool IsRequirementAccessLevel()
        {
            return UserType == UserType.RequirementAccessLevel;
        }

        public bool IsSellerAccessLevel()
        {
            return UserType == UserType.SellerAccessLevel;
        }

        public bool IsNormalAccessLevel()
        {
            return IsAdminAccessLevel() || IsBuyerAccessLevel() || IsRequirementAccessLevel() || IsSellerAccessLevel();
        }

        public bool IsUserAuthenticated()
        {
            return UserId != null;
        }

        public bool IsAccountAuthenticated()
        {
            return UserType != UserType.None && (AccountPermissions != null || !IsNormalAccessLevel());
        }

        public bool IsAuthenticated()
        {
            return IsUserAuthenticated() && IsAccountAuthenticated();
        }

        public void SetAdministratorUserId()
        {
            if (ChangingEnable)
            {
                SetAdministratorAndGeneralUserId();
            }
            else
            {
                throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
            }
        }

        public void SetGeneralUserId()
        {
            if (ChangingEnable)
            {
                SetAdministratorAndGeneralUserId();
            }
            else
            {
                throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
            }
        }

        public void SetNormalUserId(int inUserId)
        {
            if (ChangingEnable)
            {
                UserId = inUserId;
            }
            else
            {
                throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
            }
        }

        public void SetUserType(AccountType inAccountType)
        {
            if (ChangingEnable)
            {
                switch (inAccountType)
                {
                    case AccountType.Administrator:
                        UserType = UserType.AdminAccessLevel;
                        break;
                    case AccountType.Buyer:
                        UserType = UserType.BuyerAccessLevel;
                        break;
                    case AccountType.Requirement:
                        UserType = UserType.RequirementAccessLevel;
                        break;
                    case AccountType.Seller:
                        UserType = UserType.SellerAccessLevel;
                        break;
                }
            }
            else
            {
                throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
            }
        }

        public void AddPermission(IEnumerable<int> inPermissions)
        {
            if (ChangingEnable)
            {
                if (AccountPermissions == null)
                {
                    AccountPermissions = new List<int>();
                }

                AccountPermissions.AddRange(inPermissions);
            }
            else
            {
                throw ExceptionFactory.GetNewGeneralIssueException(null, "The data object is read only.");
            }
        }

        public bool CheckPermission(IEnumerable<int> inPermissions)
        {
            return inPermissions.All(permission => AccountPermissions.Contains(permission));
        }

        public bool CheckPermission(params int[] inPermissions)
        {
            return CheckPermission((IEnumerable<int>)inPermissions);
        }

        #endregion
    }
}
