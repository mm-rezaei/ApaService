using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Comminucation.Service.Win.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("bad019ca-3ebb-4e40-bbe3-9981afc9d45a"); }
        }

        public string Version
        {
            get { return "1.2.103.1411"; }
        }

        #endregion
    }
}
