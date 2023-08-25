using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Bol.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("16a63400-9d3a-4342-bf18-038f4c63a0c2"); }
        }

        public string Version
        {
            get { return "1.2.105.1411"; }
        }

        #endregion
    }
}
