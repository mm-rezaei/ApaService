using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Framework.Bol.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("d6d2ac53-be12-4f36-927c-8bf816cb8316"); }
        }

        public string Version
        {
            get { return "1.2.102.1411"; }
        }

        #endregion
    }
}
