using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Exceptions
{
    public sealed class GeneralIssueException : ExceptionBase
    {
        #region Constructors

        internal GeneralIssueException(ExceptionArgs inArgument)
            : base(inArgument)
        {
        }

        #endregion

        #region Public Properties

        public override ExceptionType Type
        {
            get { return ExceptionType.GeneralIssue; }
        }

        #endregion
    }
}