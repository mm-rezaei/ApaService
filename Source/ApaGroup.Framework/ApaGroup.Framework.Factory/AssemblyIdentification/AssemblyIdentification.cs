using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Factory.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("1b7365ca-a9e9-442c-89f1-3f3a49e5bb98"); }
        }

        public string Version
        {
            get { return "1.2.101.1411"; }
        }

        #endregion
    }
}
