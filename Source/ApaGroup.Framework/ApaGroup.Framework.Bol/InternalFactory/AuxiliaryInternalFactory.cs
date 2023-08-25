using ApaGroup.Framework.Bol.Auxiliaries;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.InternalFactory
{
    public static class AuxiliaryInternalFactory
    {
        #region Public Methods

        public static IConfigurationXmlDocumentAuxiliaryArgs GetNewConfigurationXmlDocumentAuxiliaryArgs(string inFilePath)
        {
            var result = new ConfigurationXmlDocumentAuxiliaryArgs { FilePath = inFilePath };

            return result;
        }

        public static IFileAuxiliaryArgs GetNewFileAuxiliaryArgs(string inFilePath)
        {
            var result = new FileAuxiliaryArgs { FilePath = inFilePath };

            return result;
        }

        public static IRegistryAuxiliaryArgs GetNewRegistryAuxiliaryArgs(RegistryMainRootType inMainRoot)
        {
            var result = new RegistryAuxiliaryArgs(inMainRoot);

            return result;
        }

        public static IXmlDocumentAuxiliaryArgs GetNewXmlDocumentAuxiliaryArgs(string inFilePath)
        {
            var result = new XmlDocumentAuxiliaryArgs { FilePath = inFilePath };

            return result;
        }

        public static IConfigurationXmlDocumentAuxiliary GetNewConfigurationXmlDocumentAuxiliary(
            IConfigurationXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            var result = new ConfigurationXmlDocumentAuxiliary(inAuxiliaryArgs);

            return result;
        }

        public static IFileAuxiliary GetNewFileAuxiliary(IFileAuxiliaryArgs inAuxiliaryArgs)
        {
            var result = new FileAuxiliary(inAuxiliaryArgs);

            return result;
        }

        public static IRegistryAuxiliary GetNewRegistryAuxiliary(IRegistryAuxiliaryArgs inAuxiliaryArgs)
        {
            var result = new RegistryAuxiliary(inAuxiliaryArgs);

            return result;
        }

        public static IXmlDocumentAuxiliary GetNewmlDocumentAuxiliary(IXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            var result = new XmlDocumentAuxiliary(inAuxiliaryArgs);

            return result;
        }

        #endregion
    }
}
