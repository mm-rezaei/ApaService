using System.Collections.Generic;
using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Exceptions
{
    public sealed class ModelValidationException : ExceptionBase
    {
        #region Constructors

        internal ModelValidationException(ExceptionArgs inArgument)
            : base(inArgument)
        {
            ValidationMessages = (IEnumerable<object>)inArgument.SpecialData;
        }

        #endregion

        #region Public Properties

        public override ExceptionType Type
        {
            get { return ExceptionType.ModelValidation; }
        }

        public IEnumerable<object> ValidationMessages { get; private set; }

        #endregion
    }
}
