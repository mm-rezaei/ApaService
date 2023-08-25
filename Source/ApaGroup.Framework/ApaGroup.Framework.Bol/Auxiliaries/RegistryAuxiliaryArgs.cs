using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class RegistryAuxiliaryArgs : AuxiliaryArgsBase, IRegistryAuxiliaryArgs
    {
        #region Constructors

        internal RegistryAuxiliaryArgs(RegistryMainRootType inMainRoot)
        {
            MainRoot = inMainRoot;
        }

        #endregion

        #region Public Properties

        public RegistryMainRootType MainRoot { get; set; }

        #endregion
    }
}