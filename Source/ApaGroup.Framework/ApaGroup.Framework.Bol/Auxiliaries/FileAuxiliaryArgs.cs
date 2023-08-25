using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class FileAuxiliaryArgs : AuxiliaryArgsBase, IFileAuxiliaryArgs
    {
        #region Constructors

        internal FileAuxiliaryArgs()
        {
        }

        #endregion

        #region Public Properties

        public string FilePath { get; set; }

        #endregion
    }
}