using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IConfigurationXmlDocumentAuxiliaryArgs : IAuxiliaryArgs
    {
        #region Public Properties

        string FilePath { get; set; }

        #endregion
    }
}