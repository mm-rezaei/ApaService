using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Framework.IBol.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("7d01ad78-c10c-4f15-b36f-7791d5397d64"); }
        }

        public string Version
        {
            get { return "1.2.102.1411"; }
        }

        #endregion
    }
}
