using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class ComparisonHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static bool BinaryArrayEquals(byte[] inBinaryValue1, byte[] inBinaryValue2)
        {
            return Assistant.Comparison.BinaryArrayEquals(inBinaryValue1, inBinaryValue2);
        }

        public static bool IsSpesificLetter(char inLetter, LetterType inLetterType)
        {
            return Assistant.Comparison.IsSpesificLetter(inLetter, inLetterType);
        }

        #endregion
    }
}
