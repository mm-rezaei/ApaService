using System;
using System.Linq;
using System.Reflection;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.Bol.Cores.WorkFlowMachines
{
    public abstract class WorkflowActionBase
    {
        #region Public Properties

        public static WorkflowAction Save
        {
            get { return WorkflowAction.Save; }
        }

        public static WorkflowAction Delete
        {
            get { return WorkflowAction.Delete; }
        }

        #endregion

        #region Public Methods

        public static string ToString<TWorkflowActionType>(WorkflowAction inWorkflowAction)
            where TWorkflowActionType : WorkflowActionBase
        {
            string result;

            try
            {
                result =
                    ReflectionHelper.GetProperties<TWorkflowActionType>(BindingFlags.FlattenHierarchy |
                                                                        BindingFlags.Public |
                                                                        BindingFlags.Static)
                        .Single(property => Convert.ToInt32(property.GetValue(null)) == (int)inWorkflowAction)
                        .Name;
            }
            catch (ArgumentNullException ex)
            {
                throw ExceptionFactory.GetNewWorkflowActionNotFoundException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw ExceptionFactory.GetNewWorkflowActionNotFoundException(ex);
            }

            return result;
        }

        public static WorkflowAction Parse<TWorkflowActionType>(string inStringValue)
            where TWorkflowActionType : WorkflowActionBase
        {
            WorkflowAction result;

            try
            {
                result = (WorkflowAction)ConvertorHelper.ToInt32(ReflectionHelper.GetProperties<TWorkflowActionType>(
                     BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static)
                                                         .Single(property => property.Name == inStringValue)
                                                         .GetValue(null));
            }
            catch (ArgumentNullException ex)
            {
                throw ExceptionFactory.GetNewWorkflowActionNotFoundException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw ExceptionFactory.GetNewWorkflowActionNotFoundException(ex);
            }

            return result;
        }

        #endregion
    }
}