using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Framework.Dal.DataStructure.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("24d365e1-7666-459f-a884-cdd32f628b87"); }
        }

        public string Version
        {
            get { return "1.2.102.1411"; }
        }

        #endregion
    }
}
