using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaGroup.Framework.Bol.Constants
{
    public class ApaGroupFrameworkBolConstant : ConstantBase
    {
        #region Private Fields

        private static readonly ApaGroupFrameworkBolConstant _Instance = new ApaGroupFrameworkBolConstant();

        #endregion

        #region Internal Properties

        public static ApaGroupFrameworkBolConstant Instance
        {
            get { return _Instance; }
        }

        #endregion

        #region Public Properties

        internal char RegistryPathSeparator
        {
            get { return '\\'; }
        }

        internal string RegistryRootName
        {
            get { return "ApaGroup"; }
        }

        internal string RegistryKeyDefaultValue
        {
            get { return "DefaultValue"; }
        }

        #endregion
    }
}