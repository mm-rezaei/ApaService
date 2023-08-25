using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Comminucation.Service.Web.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("e6c33f6a-913c-4e5e-a5d6-785b0dbb7e3a"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
