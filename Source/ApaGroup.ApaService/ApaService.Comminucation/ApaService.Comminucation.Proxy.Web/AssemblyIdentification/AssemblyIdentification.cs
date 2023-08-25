using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Comminucation.Proxy.Web.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("7bc5971d-aea4-4df1-9895-330a0bf80294"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
