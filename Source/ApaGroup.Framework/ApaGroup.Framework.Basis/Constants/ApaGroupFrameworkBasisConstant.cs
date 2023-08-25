using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaGroup.Framework.Basis.Constants
{
    public class ApaGroupFrameworkBasisConstant : ConstantBase
    {
        #region Private Fields

        private static readonly ApaGroupFrameworkBasisConstant _Instance = new ApaGroupFrameworkBasisConstant();

        #endregion

        #region Internal Properties

        public static ApaGroupFrameworkBasisConstant Instance
        {
            get { return _Instance; }
        }

        #endregion

        #region Public Properties

        public string IranDateTimeSynchronizedDay
        {
            get { return "IranDateTimeSynchronizedDay"; }
        }

        public string IranDateTimeSynchronizedHour
        {
            get { return "IranDateTimeSynchronizedHour"; }
        }

        public string IranDateTimeSynchronizedMinute
        {
            get { return "IranDateTimeSynchronizedMinute"; }
        }

        public string IranDateTimeSynchronizedSecond
        {
            get { return "IranDateTimeSynchronizedSecond"; }
        }

        #endregion
    }
}