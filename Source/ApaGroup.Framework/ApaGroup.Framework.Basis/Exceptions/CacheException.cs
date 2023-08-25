using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Exceptions
{
    public sealed class CacheException: ExceptionBase
    {
        #region Constructors

        internal CacheException(ExceptionArgs inArgument)
            : base(inArgument)
        {
        }

        #endregion

        #region Public Properties

        public override ExceptionType Type
        {
            get { return ExceptionType.Cache; }
        }

        #endregion
    }
}