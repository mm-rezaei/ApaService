using System;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class IranDateTimeHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Properties

        public static DateTime LocalDateTime
        {
            get { return Assistant.IranDateTime.LocalDateTime; }
        }

        public static DateTime TehranDateTime
        {
            get { return Assistant.IranDateTime.TehranDateTime; }
        }

        #endregion

        #region Public Methods

        public static void InitializeConfigurations()
        {
            Assistant.IranDateTime.InitializeProperties();
        }

        public static DateTime ToIranDateTime(DateTime inLocalDateTime)
        {
            return Assistant.IranDateTime.ToIranDateTime(inLocalDateTime);
        }

        public static DateTime ToLocalDateTime(DateTime inIranDateTime)
        {
            return Assistant.IranDateTime.ToLocalDateTime(inIranDateTime);
        }

        #endregion
    }
}