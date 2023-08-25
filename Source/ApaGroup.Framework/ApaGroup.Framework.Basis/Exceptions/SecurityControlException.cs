using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Exceptions
{
    public sealed class SecurityControlException : ExceptionBase
    {
        #region Constructors

        internal SecurityControlException(ExceptionArgs inArgument, string inControlType)
            : base(inArgument)
        {
            ControlType = inControlType;
        }

        #endregion

        #region Public Properties

        public override ExceptionType Type
        {
            get { return ExceptionType.SecurityControl; }
        }

        public string ControlType { get; private set; }

        #endregion
    }
}