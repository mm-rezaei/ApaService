using ApaGroup.Framework.Dal.Context.Cores.Contexts;

namespace ApaGroup.Framework.Dal.Context.Securities.Contexts
{
    internal class SecurityContextScope : ContextScopeBase
    {
        #region Constructors

        internal SecurityContextScope()
            : base(new SecurityEntities())
        {
        }

        #endregion
    }
}
