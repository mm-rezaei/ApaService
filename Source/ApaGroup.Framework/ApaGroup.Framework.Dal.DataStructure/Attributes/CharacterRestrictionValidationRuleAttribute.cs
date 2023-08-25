
using System.Linq;
using ApaGroup.Framework.Basis.Enumerations;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class CharacterRestrictionValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Constructors

        public CharacterRestrictionValidationRuleAttribute(LetterType inLetterType)
        {
            Type = inLetterType;

            _CustomMessage = "از کاراکترهای غیر مجاز استفاده گردیده است.";
        }

        #endregion

        #region Private Fields

        private string _CustomMessage;

        #endregion

        #region Private Properties

        private LetterType Type { get; set; }

        #endregion

        #region Public Properties

        public override string Message
        {
            get { return _CustomMessage; }
            set { _CustomMessage = value; }
        }

        #endregion

        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result =
                inObject.ToString()
                    .ToCharArray()
                    .Where(letter => letter != 0)
                    .AsParallel()
                    .FirstOrDefault(letter => !ComparisonHelper.IsSpesificLetter(letter, Type)) == 0;

            return result;
        }

        #endregion
    }
}
