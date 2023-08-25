using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IRegistryAuxiliaryArgs : IAuxiliaryArgs
    {
        #region Public Properties

        RegistryMainRootType MainRoot { get; set; }

        #endregion
    }
}