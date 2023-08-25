using System;
using System.Data.Entity;

namespace ApaGroup.Framework.Dal.Context.Cores.Contexts
{
    public abstract class ContextScopeBase : IDisposable
    {
        #region Constructors

        protected ContextScopeBase(DbContext inContext)
        {
            ContextInstance = inContext;

            inContext.Configuration.ProxyCreationEnabled = false;
            inContext.Configuration.LazyLoadingEnabled = false;
        }

        ~ContextScopeBase()
        {
            Dispose();
        }

        #endregion

        #region Public properties

        public DbContext ContextInstance { get; private set; }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            if (ContextInstance != null)
            {
                ContextInstance.Dispose();
            }
        }

        #endregion
    }
}
