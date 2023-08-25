using ApaGroup.Framework.Identification.Cores;
using System;

namespace ApaService.Comminucation.Security.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("b28ead64-2cee-447d-9494-ad9247340bde"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
