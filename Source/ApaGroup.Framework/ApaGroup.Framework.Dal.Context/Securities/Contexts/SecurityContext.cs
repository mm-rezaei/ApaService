using ApaGroup.Framework.Dal.Context.Contexts;

namespace ApaGroup.Framework.Dal.Context.Securities.Contexts
{
    public class SecurityContext : ApaContext
    {
        #region Constructors

        public SecurityContext()
        {
            Scope = new SecurityContextScope();

            InitializeDatabaseContextScope(Scope);
        }

        #endregion

        #region Private Properties

        private SecurityContextScope Scope { get; set; }

        #endregion

        #region Public Methods

        public override void Dispose()
        {
            base.Dispose();

            Scope.Dispose();
        }

        #endregion
    }
}
