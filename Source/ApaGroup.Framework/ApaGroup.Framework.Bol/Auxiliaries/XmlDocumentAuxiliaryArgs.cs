using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class XmlDocumentAuxiliaryArgs : AuxiliaryArgsBase, IXmlDocumentAuxiliaryArgs
    {
        #region Constructors

        internal XmlDocumentAuxiliaryArgs()
        {
        }

        #endregion

        #region Public Properties

        public string FilePath { get; set; }

        #endregion
    }
}