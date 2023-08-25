using System;
using System.Configuration;
using System.IO;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Bol.Constants;
using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class ConfigurationXmlDocumentAuxiliary :
        AuxiliaryBase<ApaGroupFrameworkBolConstant, IConfigurationXmlDocumentAuxiliaryArgs>,
        IConfigurationXmlDocumentAuxiliary
    {
        #region Constructores

        internal ConfigurationXmlDocumentAuxiliary(IConfigurationXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
            : base(inAuxiliaryArgs)
        {
            CheckExistFile(ConfigurationFileFullName);

            Document = new ConfigXmlDocument();

            try
            {
                Document.Load(ConfigurationFileFullName);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewConfigurationManagementException(ex,
                    "Error on loading '" + ConfigurationFileFullName + "'.");
            }
        }

        #endregion

        #region Private Properties

        private string ConfigurationFileFullName { get; set; }

        #endregion

        #region Private Methods

        private void CheckExistFile(string inConfigurationFileFullName)
        {
            if (!File.Exists(inConfigurationFileFullName))
            {
                var fileStream = File.Create(inConfigurationFileFullName);

                var streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine("<" + inConfigurationFileFullName.Replace(".config", "") + ">");
                streamWriter.Write("</" + inConfigurationFileFullName.Replace(".config", "") + ">");

                streamWriter.Close();
            }
        }

        #endregion

        #region Protected Methods

        protected override void InitializeFromContextArgs(IConfigurationXmlDocumentAuxiliaryArgs inAuxiliaryArgs)
        {
            ConfigurationFileFullName = inAuxiliaryArgs.FilePath;
        }

        #endregion

        #region Public Properties

        public ConfigXmlDocument Document { get; private set; }

        #endregion

        #region Public Methods

        public void Load()
        {
            Document = new ConfigXmlDocument();

            try
            {
                Document.Load(ConfigurationFileFullName);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewConfigurationManagementException(ex,
                    "Error on loading '" + ConfigurationFileFullName + "'.");
            }
        }

        public void Save()
        {
            try
            {
                Document.Save(ConfigurationFileFullName);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewConfigurationManagementException(ex,
                    "Error on saving '" + ConfigurationFileFullName + "'.");
            }
        }

        public void Close()
        {
            Document = null;
        }

        #endregion
    }
}