using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class ConfigurationXmlDocumentAuxiliaryArgs : AuxiliaryArgsBase,
                                                                IConfigurationXmlDocumentAuxiliaryArgs
    {
        #region Constructors

        internal ConfigurationXmlDocumentAuxiliaryArgs()
        {
        }

        #endregion

        #region Public Properties

        public string FilePath { get; set; }

        #endregion
    }
}