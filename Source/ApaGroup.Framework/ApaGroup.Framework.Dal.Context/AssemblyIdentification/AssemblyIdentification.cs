using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Dal.Context.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("51ff8043-07ef-4019-8c79-e91235347637"); }
        }

        public string Version
        {
            get { return "1.2.101.1411"; }
        }

        #endregion
    }
}
