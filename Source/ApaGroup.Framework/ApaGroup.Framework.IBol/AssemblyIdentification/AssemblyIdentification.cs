using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.IBol.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("674389c8-562f-4754-814a-da5b7af8a079"); }
        }

        public string Version
        {
            get { return "1.2.101.1411"; }
        }

        #endregion
    }
}
