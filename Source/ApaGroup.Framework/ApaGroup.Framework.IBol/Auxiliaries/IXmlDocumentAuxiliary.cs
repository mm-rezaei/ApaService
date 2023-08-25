using System.Configuration;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IXmlDocumentAuxiliary : IAuxiliary
    {
        #region Public Properties

        ConfigXmlDocument Document { get; }

        #endregion

        #region Public Methods

        void Load();

        void Save();

        void Close();

        #endregion
    }
}