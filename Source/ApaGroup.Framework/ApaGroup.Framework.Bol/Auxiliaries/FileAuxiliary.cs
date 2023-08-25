using System;
using System.Collections.Generic;
using System.IO;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Bol.Constants;
using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Auxiliaries;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class FileAuxiliary : AuxiliaryBase<ApaGroupFrameworkBolConstant, IFileAuxiliaryArgs>, IFileAuxiliary
    {
        #region Constructors

        internal FileAuxiliary(IFileAuxiliaryArgs inAuxiliaryArgs)
            : base(inAuxiliaryArgs)
        {
        }

        #endregion

        #region Private Properties

        private string FilePath { get; set; }

        #endregion

        #region Protected Methods

        protected override void InitializeFromContextArgs(IFileAuxiliaryArgs inAuxiliaryArgs)
        {
            FilePath = inAuxiliaryArgs.FilePath;
        }

        #endregion

        #region Public Methods

        public bool Exists()
        {
            var result = File.Exists(FilePath);

            return result;
        }

        public void Copy(string inDestinationFilePath)
        {
            try
            {
                File.Copy(FilePath, inDestinationFilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public void Delete()
        {
            try
            {
                File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public void Move(string inDestinationFilePath, bool inChangePathToNewFile)
        {
            try
            {
                File.Move(FilePath, inDestinationFilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }

            if (inChangePathToNewFile)
            {
                FilePath = inDestinationFilePath;
            }
        }

        public void Create(bool inOverWritesIt)
        {
            if (!Exists() || inOverWritesIt)
            {
                try
                {
                    File.Create(FilePath);
                }
                catch (Exception ex)
                {
                    throw ExceptionFactory.GetNewFileException(ex);
                }
            }
        }

        public byte[] ReadAllBytes()
        {
            byte[] result;

            try
            {
                result = File.ReadAllBytes(FilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }

            return result;
        }

        public void WriteAllBytes(byte[] inContent)
        {
            try
            {
                File.WriteAllBytes(FilePath, inContent);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public string ReadAllText()
        {
            string result;

            try
            {
                result = File.ReadAllText(FilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }

            return result;
        }

        public void WriteAllText(string inContent)
        {
            try
            {
                File.WriteAllText(FilePath, inContent);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public IEnumerable<string> ReadAllLines()
        {
            string[] result;

            try
            {
                result = File.ReadAllLines(FilePath);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }

            return result;
        }

        public void WriteAllLines(IEnumerable<string> inContent)
        {
            try
            {
                File.WriteAllLines(FilePath, inContent);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public void AppendText(string inText)
        {
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = File.AppendText(FilePath);

                streamWriter.Write(inText);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        public void AppendLine(string inLine)
        {
            try
            {
                AppendLines(new List<string> { inLine });
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        public void AppendLines(IEnumerable<string> inLines)
        {
            try
            {
                File.AppendAllLines(FilePath, inLines);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewFileException(ex);
            }
        }

        #endregion
    }
}