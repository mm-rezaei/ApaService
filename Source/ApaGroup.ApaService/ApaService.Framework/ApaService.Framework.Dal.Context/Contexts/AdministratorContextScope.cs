using ApaService.Framework.Dal.Context.Cores.Contexts;

namespace ApaService.Framework.Dal.Context.Contexts
{
    public class AdministratorContextScope : ApasContextScopeBase
    {
        #region Constructors

        public AdministratorContextScope()
            : base(new AdministratorEntities())
        {
        }

        #endregion
    }
}
