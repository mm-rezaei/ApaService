using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Comminucation.Bol.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("ad332032-5e0b-4563-9c65-3f63fe4de271"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
