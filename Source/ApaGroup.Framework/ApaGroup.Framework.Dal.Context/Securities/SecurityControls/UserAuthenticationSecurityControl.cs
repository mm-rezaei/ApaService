using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Contexts;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.Context.Securities.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Securities.Enumerations;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level1 | SecurityControlLevelNumber.Level2)]
    internal sealed class UserAuthenticationSecurityControl : SecurityControlBase
    {
        #region Constructors

        private UserAuthenticationSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private byte[] _GeneralUserPassword;

        private static readonly UserAuthenticationSecurityControl _Instance = new UserAuthenticationSecurityControl();

        #endregion

        #region Private Properties

        private byte[] AdministratorUserPassword
        {
            get
            {
                var result = ConfigurationManagementHelper.GetConfiguration<string>("AdministratorPassword").Split(',').Select(ConvertorHelper.ToByte).ToArray();

                return result;
            }
        }

        private byte[] GeneralUserPassword
        {
            get
            {
                return _GeneralUserPassword ?? (_GeneralUserPassword = new byte[]
                {
                    224, 153, 79, 127, 166, 2, 158, 253, 25, 44, 244, 172, 233, 38, 54, 74, 122, 98, 139, 138, 98, 173, 162, 235, 103, 30, 49, 92, 182, 163, 45, 230
                });
            }
        }

        #endregion

        #region Private Methods

        private bool CheckPassword(byte[] inRealPassword, byte[] inEnteredPassword)
        {
            var enteredPassword = HashingHelper.GetHashArray(inEnteredPassword);

            var result = ComparisonHelper.BinaryArrayEquals(inRealPassword, enteredPassword);

            return result;
        }

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- AuthenticationDataObject</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var authenticationDataObject = (AuthenticationDataObject)inObjects[0];

            var hasException = true;

            switch (authenticationDataObject.UserType)
            {
                case UserType.Administrator:
                    #region UserType.Administrator

                    if (CheckPassword(AdministratorUserPassword, authenticationDataObject.Password))
                    {
                        hasException = false;

                        authenticationDataObject.SetAdministratorUserId();
                    }

                    #endregion
                    break;

                case UserType.General:
                    #region UserType.General

                    if (CheckPassword(GeneralUserPassword, authenticationDataObject.Password))
                    {
                        hasException = false;

                        authenticationDataObject.SetGeneralUserId();
                    }

                    #endregion
                    break;

                case UserType.AdminAccessLevel:
                case UserType.RequirementAccessLevel:
                case UserType.BuyerAccessLevel:
                case UserType.SellerAccessLevel:
                    #region UserType.Normal

                    using (var context = new SecurityContext())
                    {
                        var user = context.FetchEntity<SecurityUserDataModel>(model => model.Username == authenticationDataObject.Username, null).FirstOrDefault();

                        if (user != null)
                        {
                            var userLogin = context.FetchEntity<SecurityUserLoginDataModel>(model => model.Id == user.Id, null).FirstOrDefault();

                            if (userLogin != null && CheckPassword(userLogin.Password, authenticationDataObject.Password))
                            {
                                hasException = false;

                                authenticationDataObject.SetNormalUserId(user.Id);
                            }
                        }
                    }

                    #endregion
                    break;
            }

            if (authenticationDataObject.UserType == UserType.None)
            {
                hasException = true;
            }

            SecurityControlHelper.CheckServiceSecurityControl(authenticationDataObject.Username, !hasException);

            if (hasException)
            {
                throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.UserAuthenticationFailed.ToString());
            }
        }

        #endregion

        #region Public Properties

        public static UserAuthenticationSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
