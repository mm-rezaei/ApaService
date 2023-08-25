using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Comminucation.Proxy.Win.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("6da96308-7411-4b79-b0f0-9a7de129aac1"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
