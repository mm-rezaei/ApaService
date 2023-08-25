using System.Collections.Generic;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.IBol.Auxiliaries
{
    public interface IFileAuxiliary : IAuxiliary
    {
        #region Public Methods

        bool Exists();

        void Copy(string inDestinationFilePath);

        void Delete();

        void Move(string inDestinationFilePath, bool inChangePathToNewFile);

        void Create(bool inOverWritesIt);

        byte[] ReadAllBytes();

        void WriteAllBytes(byte[] inContent);

        string ReadAllText();

        void WriteAllText(string inContent);

        IEnumerable<string> ReadAllLines();

        void WriteAllLines(IEnumerable<string> inContent);

        void AppendText(string inText);

        void AppendLine(string inLine);

        void AppendLines(IEnumerable<string> inLines);

        #endregion
    }
}