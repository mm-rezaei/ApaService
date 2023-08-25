using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Basis.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("242b9e6d-2475-491b-80b0-fe8d50df08ad"); }
        }

        public string Version
        {
            get { return "1.2.104.1411"; }
        }

        #endregion
    }
}
