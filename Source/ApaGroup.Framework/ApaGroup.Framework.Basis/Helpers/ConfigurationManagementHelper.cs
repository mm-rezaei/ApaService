using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class ConfigurationManagementHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static void InitializeConfigurations()
        {
            Assistant.Configuration.InitializeProperties();
        }

        public static bool Contains(string inConfigurationKey)
        {
            return Assistant.Configuration.Contains(inConfigurationKey);
        }

        public static TConfigurationType GetConfiguration<TConfigurationType>(string inConfigurationKey)
        {
            return Assistant.Configuration.GetConfiguration<TConfigurationType>(inConfigurationKey);
        }

        public static void SetConfiguration<TConfigurationType>(string inConfigurationKey,
                                                                TConfigurationType inConfigurationValue)
        {
            Assistant.Configuration.SetConfiguration(inConfigurationKey, inConfigurationValue);
        }

        #endregion
    }
}