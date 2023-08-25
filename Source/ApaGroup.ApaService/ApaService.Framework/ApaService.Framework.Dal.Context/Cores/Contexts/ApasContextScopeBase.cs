using ApaGroup.Framework.Dal.Context.Cores.Contexts;
using System.Data.Entity;

namespace ApaService.Framework.Dal.Context.Cores.Contexts
{
    public abstract class ApasContextScopeBase : ContextScopeBase
    {
        #region Constructors

        protected ApasContextScopeBase(DbContext inContext)
            : base(inContext)
        {
        }

        #endregion
    }
}
