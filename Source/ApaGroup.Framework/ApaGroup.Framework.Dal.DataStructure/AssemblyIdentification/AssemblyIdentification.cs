using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Dal.DataStructure.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("c134ff5e-5ca5-42f2-b868-5f99a6f1daad"); }
        }

        public string Version
        {
            get { return "1.2.101.1411"; }
        }

        #endregion
    }
}
