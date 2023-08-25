using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaGroup.Framework.Dal.Context.Constants
{
    public class ApaGroupFrameworkDalContextConstant : ConstantBase
    {
        #region Private Fields

        private static readonly ApaGroupFrameworkDalContextConstant _Instance = new ApaGroupFrameworkDalContextConstant();

        #endregion

        #region Internal Properties

        public static ApaGroupFrameworkDalContextConstant Instance
        {
            get { return _Instance; }
        }

        #endregion

        #region Public properties

        public string UsersAccessHistoriesCacheKey
        {
            get
            {
                return "UsersAccessHistories";
            }
        }

        #endregion
    }
}