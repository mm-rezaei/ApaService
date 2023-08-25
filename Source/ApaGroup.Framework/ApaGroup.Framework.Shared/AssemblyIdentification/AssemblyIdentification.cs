using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaGroup.Framework.Shared.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("e8e4b81e-9f00-4de4-8305-b2c79421af13"); }
        }

        public string Version
        {
            get { return "1.2.101.1411"; }
        }

        #endregion
    }
}
