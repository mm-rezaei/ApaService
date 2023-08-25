
using System;

namespace ApaGroup.Framework.Basis.Cores.Exceptions
{
    public sealed class ExceptionArgs
    {
        #region Constructors

        internal ExceptionArgs(Exception inInnerException, string inSpecialMessage, object inSpecialData, string inTecnicalMessage)
        {
            InitializeProperties(inInnerException, inSpecialMessage, inSpecialData, inTecnicalMessage);
        }

        #endregion

        #region Private Methods

        private void InitializeProperties(Exception inInnerException, string inSpecialMessage, object inSpecialData, string inTecnicalMessage)
        {
            InnerException = inInnerException;
            SpecialMessage = inSpecialMessage;
            SpecialData = inSpecialData;
            TecnicalMessage = inTecnicalMessage;
        }

        #endregion

        #region Public Properties

        public Exception InnerException { get; set; }

        public string SpecialMessage { get; private set; }

        public object SpecialData { get; private set; }

        public string TecnicalMessage { get; private set; }

        #endregion
    }
}