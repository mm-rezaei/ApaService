using System.Configuration;
using ApaGroup.Framework.Bol.Constants;
using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.Bol.InternalFactory;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class XmlDocumentAuxiliary : AuxiliaryBase<ApaGroupFrameworkBolConstant, IXmlDocumentAuxiliaryArgs>,
                                               IXmlDocumentAuxiliary
    {
        #region Constructors

        internal XmlDocumentAuxiliary(IXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
            : base(inAuxiliaryArgs)
        {
        }

        #endregion

        #region Private Fields

        private IConfigurationXmlDocumentAuxiliary _Auxiliary;

        #endregion

        #region Private Properties

        private string FilePath { get; set; }

        private IConfigurationXmlDocumentAuxiliary Auxiliary
        {
            get
            {
                return _Auxiliary ??
                       (_Auxiliary =
                        AuxiliaryInternalFactory.GetNewConfigurationXmlDocumentAuxiliary(
                            AuxiliaryInternalFactory.GetNewConfigurationXmlDocumentAuxiliaryArgs(FilePath)));
            }
        }

        #endregion

        #region Protected Methods

        protected override void InitializeFromContextArgs(IXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            FilePath = inAuxiliaryArgs.FilePath;
        }

        #endregion

        #region Public Properties

        public ConfigXmlDocument Document
        {
            get { return Auxiliary.Document; }
        }

        #endregion

        #region Public Methods

        public void Load()
        {
            Auxiliary.Load();
        }

        public void Save()
        {
            Auxiliary.Save();
        }

        public void Close()
        {
            Auxiliary.Close();
        }

        #endregion
    }
}