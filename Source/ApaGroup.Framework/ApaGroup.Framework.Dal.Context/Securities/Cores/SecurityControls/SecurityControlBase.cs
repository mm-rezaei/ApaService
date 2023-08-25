using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;

namespace ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls
{
    public abstract class SecurityControlBase
    {
        #region Protected Properties

        protected virtual bool IsEnable
        {
            get { return true; }
        }

        #endregion

        #region Protected Methods

        protected void ThrowSecurityControlException(SecurityControlType inSecurityControlType)
        {
            throw ExceptionFactory.GetNewSecurityControlException(inSecurityControlType.ToString());
        }

        protected abstract void CheckSecurityOptions(params object[] inObjects);

        #endregion

        #region Public Methods

        public void Check(params object[] inObjects)
        {
            if (IsEnable)
            {
                CheckSecurityOptions(inObjects);
            }
        }

        #endregion
    }
}
