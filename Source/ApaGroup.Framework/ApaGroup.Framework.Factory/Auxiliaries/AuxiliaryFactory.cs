using ApaGroup.Framework.Bol.InternalFactory;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Factory.Auxiliaries
{
    public class AuxiliaryFactory
    {
        #region Constructors

        private AuxiliaryFactory()
        {
        }

        #endregion

        #region Private  Fields

        private static readonly AuxiliaryFactory _Instance = new AuxiliaryFactory();

        #endregion

        #region Public Properties

        public static AuxiliaryFactory Instance
        {
            get { return _Instance; }
        }

        #endregion

        #region Public Methods

        public static IConfigurationXmlDocumentAuxiliaryArgs GetNewConfigurationXmlDocumentAuxiliaryArgs(string inFilePath)
        {
            return AuxiliaryInternalFactory.GetNewConfigurationXmlDocumentAuxiliaryArgs(inFilePath);
        }

        public static IFileAuxiliaryArgs GetNewFileAuxiliaryArgs(string inFilePath)
        {
            return AuxiliaryInternalFactory.GetNewFileAuxiliaryArgs(inFilePath);
        }

        public static IRegistryAuxiliaryArgs GetNewRegistryAuxiliaryArgs(RegistryMainRootType inMainRoot)
        {
            return AuxiliaryInternalFactory.GetNewRegistryAuxiliaryArgs(inMainRoot);
        }

        public static IXmlDocumentAuxiliaryArgs GetNewXmlDocumentAuxiliaryArgs(string inFilePath)
        {
            return AuxiliaryInternalFactory.GetNewXmlDocumentAuxiliaryArgs(inFilePath);
        }

        public static IConfigurationXmlDocumentAuxiliary GetNewConfigurationXmlDocumentAuxiliary(
            IConfigurationXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            return AuxiliaryInternalFactory.GetNewConfigurationXmlDocumentAuxiliary(inAuxiliaryArgs);
        }

        public static IFileAuxiliary GetNewFileAuxiliary(IFileAuxiliaryArgs inAuxiliaryArgs)
        {
            return AuxiliaryInternalFactory.GetNewFileAuxiliary(inAuxiliaryArgs);
        }

        public static IRegistryAuxiliary GetNewRegistryAuxiliary(IRegistryAuxiliaryArgs inAuxiliaryArgs)
        {
            return AuxiliaryInternalFactory.GetNewRegistryAuxiliary(inAuxiliaryArgs);
        }

        public static IXmlDocumentAuxiliary GetNewmlDocumentAuxiliary(IXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            return AuxiliaryInternalFactory.GetNewmlDocumentAuxiliary(inAuxiliaryArgs);
        }

        #endregion
    }
}
