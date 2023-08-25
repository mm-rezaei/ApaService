using System;
using ApaGroup.Framework.Identification.Cores;

namespace ApaService.Framework.Dal.Context.AssemblyIdentification
{
    public sealed class AssemblyIdentification : IAssemblyIdentification
    {
        #region Public Properties

        public Guid Identifier
        {
            get { return new Guid("e7cc88c3-9448-46d4-9199-bf237e22eb63"); }
        }

        public string Version
        {
            get { return "1.2.106.1412"; }
        }

        #endregion
    }
}
