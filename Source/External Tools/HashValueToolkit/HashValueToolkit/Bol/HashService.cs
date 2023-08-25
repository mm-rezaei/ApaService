
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashValueToolkit.Bol
{
    internal class HashService
    {
        #region Private Methods

        private static byte[] GetHashArray(byte[] inByteArray)
        {
            var shaObject = new SHA256Managed();

            var result = shaObject.ComputeHash(inByteArray);

            return result;
        }

        #endregion

        #region Public Methods

        public static byte[] GetHashValue(string inValue, int inActionCount)
        {
            var result = Encoding.UTF8.GetBytes(inValue);

            for (var index = 0; index < inActionCount; index++)
            {
                result = GetHashArray(result);
            }

            return result;
        }

        public static string GetHashString(string inValue, int inActionCount)
        {
            return Convert.ToBase64String(GetHashValue(inValue, inActionCount));
        }

        #endregion
    }
}
