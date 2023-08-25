using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class ConvertorHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static TCastType GetCastValue<TCastType>(object inObject)
        {
            return Assistant.Convertion.GetCastValue<TCastType>(inObject);
        }

        public static byte ToByte(object inObject)
        {
            return Assistant.Convertion.ToByte(inObject);
        }

        public static int ToInt32(object inObject)
        {
            return Assistant.Convertion.ToInt32(inObject);
        }

        public static double ToDouble(object inObject)
        {
            return Assistant.Convertion.ToDouble(inObject);
        }

        public static float ToFloat(object inObject)
        {
            return Assistant.Convertion.ToFloat(inObject);
        }

        public static byte[] ToByteArray(string inString)
        {
            return Assistant.Convertion.ToByteArray(inString);
        }

        #endregion
    }
}