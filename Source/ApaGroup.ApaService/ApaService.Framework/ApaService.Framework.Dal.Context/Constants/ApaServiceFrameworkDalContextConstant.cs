using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaService.Framework.Dal.Context.Constants
{
    public class ApaServiceFrameworkDalContextConstant : ConstantBase
    {
        #region Private Fields

        private static ApaServiceFrameworkDalContextConstant _Instance;

        #endregion

        #region Internal Properties

        public static ApaServiceFrameworkDalContextConstant Instance
        {
            get { return _Instance ?? (_Instance = new ApaServiceFrameworkDalContextConstant()); }
        }

        #endregion
    }
}
