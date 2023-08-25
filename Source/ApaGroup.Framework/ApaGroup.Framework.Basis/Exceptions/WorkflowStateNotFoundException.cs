using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Exceptions
{
    public sealed class WorkflowStateNotFoundException : ExceptionBase
    {
        #region Constructors

        internal WorkflowStateNotFoundException(ExceptionArgs inArgument)
            : base(inArgument)
        {
        }

        #endregion

        #region Public Properties

        public override ExceptionType Type
        {
            get { return ExceptionType.WorkflowStateNotFound; }
        }

        #endregion
    }
}
