using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;
using System;
using System.Security.Cryptography;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class HashingHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static byte[] GetHashArray(byte[] inByteArray, int inAction)
        {
            var shaObject = new SHA256Managed();

            var result = inByteArray;

            for (var index = 0; index < inAction; index++)
            {
                result = shaObject.ComputeHash(result);
            }

            return result;
        }

        public static byte[] GetHashArray(byte[] inByteArray)
        {
            return GetHashArray(inByteArray, 1);
        }

        public static string GetHashString(byte[] inByteArray, int inAction)
        {
            return Convert.ToBase64String(GetHashArray(inByteArray, inAction));
        }

        public static string GetHashString(byte[] inByteArray)
        {
            return GetHashString(inByteArray, 1);
        }

        #endregion
    }
}
