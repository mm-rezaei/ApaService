using System;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Contexts;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level10)]
    internal sealed class AccountAuthenticationSecurityControl : SecurityControlBase
    {
        #region Constructors

        private AccountAuthenticationSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private IList<int> _GeneralUserPermissions;

        private static readonly AccountAuthenticationSecurityControl _Instance = new AccountAuthenticationSecurityControl();

        #endregion

        #region Private Properties

        private IEnumerable<int> GeneralUserPermissions
        {
            get { return _GeneralUserPermissions ?? (_GeneralUserPermissions = new List<int>() /* Add General User Permission To The List. */); }
        }

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- AuthenticationDataObject</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var authenticationDataObject = (AuthenticationDataObject)inObjects[0];

            #region Authenticate Current User By Account Id

            if (authenticationDataObject.IsUserAuthenticated())
            {
                if (!authenticationDataObject.IsAccountAuthenticated())
                {
                    using (var context = new SecurityContext())
                    {
                        var account = context.FetchEntity<SecurityAccountDataModelBase>(model => model.Id == authenticationDataObject.AccountId && model.UserId == authenticationDataObject.UserId && model.Enable, null).FirstOrDefault();

                        if (account == null)
                        {
                            throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.AccountAuthenticationFailed.ToString());
                        }

                        authenticationDataObject.StartChanging();

                        var accountType = (AccountType)Enum.Parse(typeof(AccountType), account.AccountType);

                        authenticationDataObject.SetUserType(accountType);

                        authenticationDataObject.StopChanging();
                    }
                }
            }
            else
            {
                throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.AccountAuthenticationFailed.ToString());
            }

            #endregion

            #region Fill Account Permissions

            authenticationDataObject.StartChanging();

            if (authenticationDataObject.IsGeneralUser())
            {
                #region General User Permission

                authenticationDataObject.AddPermission(GeneralUserPermissions);

                #endregion
            }
            else if (authenticationDataObject.IsNormalAccessLevel())
            {
                #region Normal User Permission

                using (var context = new SecurityContext())
                {
                    var permissions = context.FetchEntity<SecurityPrivacyAccountPermissionDataModel>(model => model.AccountId == authenticationDataObject.AccountId).Select(model => model.PrivacyPermisionId);

                    authenticationDataObject.AddPermission(permissions);
                }

                #endregion
            }

            authenticationDataObject.StopChanging();

            #endregion
        }

        #endregion

        #region Public Properties

        public static AccountAuthenticationSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
