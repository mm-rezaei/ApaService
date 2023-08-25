using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Securities.DataObjects;
using System.Linq;
using System.Reflection;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level3)]
    internal sealed class PermissionAccessSecurityControl : SecurityControlBase
    {
        #region Constructors

        private PermissionAccessSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private static readonly PermissionAccessSecurityControl _Instance = new PermissionAccessSecurityControl();

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- AuthenticationDataObject 2- MethodInfo</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var authenticationDataObject = (AuthenticationDataObject)inObjects[0];
            var methodInfo = (MethodInfo)inObjects[1];

            if (!authenticationDataObject.IsAdministratorUser())
            {
                var methodPermissions = ReflectionHelper.GetCustomAttributes<PermissionAttribute>(methodInfo, true)
                    .Select(attribute => (int)attribute.Type);

                if (!authenticationDataObject.CheckPermission(methodPermissions))
                {
                    throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.PermissionAccessDenied.ToString());
                }
            }
        }

        #endregion

        #region Public Properties

        public static PermissionAccessSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
