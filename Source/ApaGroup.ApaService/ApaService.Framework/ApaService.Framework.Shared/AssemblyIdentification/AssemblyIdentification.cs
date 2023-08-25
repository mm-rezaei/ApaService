using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Framework.Shared.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("bc5b04d1-e554-4307-8c9b-ac692ada8fd9"); }
        }

        public string Version
        {
            get { return "1.2.102.1411"; }
        }

        #endregion
    }
}
