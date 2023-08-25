using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IXmlDocumentAuxiliaryArgs : IAuxiliaryArgs
    {
        #region Public Properties

        string FilePath { get; set; }

        #endregion
    }
}