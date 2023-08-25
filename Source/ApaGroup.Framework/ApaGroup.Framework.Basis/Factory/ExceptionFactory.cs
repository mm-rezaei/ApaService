using System;
using System.Collections.Generic;
using ApaGroup.Framework.Basis.Cores.Exceptions;
using ApaGroup.Framework.Basis.Exceptions;

namespace ApaGroup.Framework.Basis.Factory
{
    public static class ExceptionFactory
    {
        #region Internal Methods

        internal static ExceptionArgs GetNewExceptionArgs(Exception inInnerException, string inSpecialMessage = "", object inSpecialData = null, string inTecnicalMessage = "")
        {
            var result = new ExceptionArgs(inInnerException, inSpecialMessage, inSpecialData, inTecnicalMessage);

            return result;
        }

        internal static ReflectionException GetNewReflectionException(Exception inInnerException, string inTecnicalMessage = "")
        {
            var result = new ReflectionException(GetNewExceptionArgs(inInnerException, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        internal static EventTrackerException GetNewEventTrackerException(Exception inInnerException)
        {
            var result = new EventTrackerException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static CacheException GetNewCacheException(string inExceptionMessage)
        {
            var result = new CacheException(GetNewExceptionArgs(null, inExceptionMessage));

            return result;
        }

        #endregion

        #region Public Methods

        public static ConfigurationManagementException GetNewConfigurationManagementException(Exception inInnerException, string inTecnicalMessage = "")
        {
            var result = new ConfigurationManagementException(GetNewExceptionArgs(inInnerException, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        public static ConcurrencyException GetNewConcurrencyException(Exception inInnerException, string inTecnicalMessage = "")
        {
            var result =
                new ConcurrencyException(GetNewExceptionArgs(inInnerException, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        public static DatabaseException GetNewDatabaseException(Exception inInnerException)
        {
            var result =
                new DatabaseException(GetNewExceptionArgs(inInnerException,
                    inTecnicalMessage: inInnerException == null ? "" : inInnerException.Message));

            return result;
        }

        public static InvalidServiceActionException GetNewInvalidServiceActionException(string inTecnicalMessage)
        {
            var result =
                new InvalidServiceActionException(GetNewExceptionArgs(null, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        public static ModelValidationException GetNewModelValidationException(IEnumerable<object> inValidationMessages)
        {
            var result = new ModelValidationException(GetNewExceptionArgs(null, inSpecialData: inValidationMessages));

            return result;
        }

        public static WorkflowActionNotFoundException GetNewWorkflowActionNotFoundException(Exception inInnerException)
        {
            var result = new WorkflowActionNotFoundException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static WorkflowStateNotFoundException GetNewWorkflowStateNotFoundException(Exception inInnerException)
        {
            var result =
                new WorkflowStateNotFoundException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static FactoryException GetNewFactoryException(Exception inInnerException, string inTecnicalMessage)
        {
            var result =
                new FactoryException(GetNewExceptionArgs(inInnerException, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        public static TypeConversionException GetNewTypeConversionException(Exception inInnerException)
        {
            var result =
                new TypeConversionException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static FileException GetNewFileException(Exception inInnerException)
        {
            var result =
                new FileException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static RegistryException GetNewRegistryException(Exception inInnerException)
        {
            var result =
                new RegistryException(GetNewExceptionArgs(inInnerException));

            return result;
        }

        public static GeneralIssueException GetNewGeneralIssueException(Exception inInnerException, string inTecnicalMessage = "")
        {
            var result =
                new GeneralIssueException(GetNewExceptionArgs(inInnerException, inTecnicalMessage: inTecnicalMessage));

            return result;
        }

        public static SecurityControlException GetNewSecurityControlException(string inControlType)
        {
            var result = new SecurityControlException(GetNewExceptionArgs(null), inControlType);

            return result;
        }

        #endregion
    }
}
