using ApaGroup.Framework.Basis.Cores.Helpers;
using ApaGroup.Framework.Dal.Context.Constants;
using ApaGroup.Framework.Dal.Context.Securities.SecurityControls;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace ApaGroup.Framework.Dal.Context.Securities.Helpers
{
    public class SecurityControlHelper : HelperBase<ApaGroupFrameworkDalContextConstant>
    {
        #region Public Methods

        public static void CheckAccountAuthenticationSecurityControl(AuthenticationDataObject inAuthenticationDataObject)
        {
            AccountAuthenticationSecurityControl.Instance.Check(inAuthenticationDataObject);
        }

        public static void CheckDataViewSavingSecurityControl(IDataModel inDataModel)
        {
            DataViewSavingSecurityControl.Instance.Check(inDataModel);
        }

        public static void CheckPermissionAccessSecurityControl(AuthenticationDataObject inAuthenticationDataObject, MethodInfo inMethodInfo)
        {
            PermissionAccessSecurityControl.Instance.Check(inAuthenticationDataObject, inMethodInfo);
        }

        public static void CheckPropertyValueChangingSecurityControl(AuthenticationDataObject inAuthenticationDataObject, IDataModel inDataModel, DbEntityEntry inEntry, Dictionary<string, object> inDefaultValue)
        {
            PropertyValueChangingSecurityControl.Instance.Check(inAuthenticationDataObject, inDataModel, inEntry, inDefaultValue);
        }

        public static void CheckSecureDataAccessSecurityControl(AuthenticationDataObject inAuthenticationDataObject, IDataModel inDataModel)
        {
            SecureDataAccessSecurityControl.Instance.Check(inAuthenticationDataObject, inDataModel);
        }

        public static void CheckServiceSecurityControl(string inUsername, bool inAccessStatus)
        {
            ServiceSecurityControl.Instance.Check(inUsername, inAccessStatus);
        }

        public static void CheckUserAuthenticationSecurityControl(AuthenticationDataObject inAuthenticationDataObject)
        {
            UserAuthenticationSecurityControl.Instance.Check(inAuthenticationDataObject);
        }

        #endregion
    }
}
