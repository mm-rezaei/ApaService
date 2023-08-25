using System;
using System.Linq;
using System.Reflection;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.Bol.Cores.WorkFlowMachines
{
    public abstract class WorkflowStateBase
    {
        #region Public Properties

        public static WorkflowState UnSaved
        {
            get { return WorkflowState.UnSaved; }
        }

        public static WorkflowState None
        {
            get { return WorkflowState.None; }
        }

        public static WorkflowState Deleted
        {
            get { return WorkflowState.Deleted; }
        }

        #endregion

        #region Public Methods

        public static string ToString<TWorkflowStateType>(WorkflowState inWorkflowState)
            where TWorkflowStateType : WorkflowStateBase
        {
            string result;

            try
            {
                result = ReflectionHelper.GetProperties<TWorkflowStateType>(BindingFlags.FlattenHierarchy | BindingFlags.Public |
                                                       BindingFlags.Static)
                    .Single(
                        property => Convert.ToInt32(property.GetValue(null)) == (int)inWorkflowState)
                    .Name;
            }
            catch (ArgumentNullException ex)
            {
                throw ExceptionFactory.GetNewWorkflowStateNotFoundException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw ExceptionFactory.GetNewWorkflowStateNotFoundException(ex);
            }

            return result;
        }

        public static WorkflowState Parse<TWorkflowStateType>(string inStringValue) where TWorkflowStateType : WorkflowStateBase
        {
            WorkflowState result;

            try
            {
                result = (WorkflowState)ConvertorHelper.ToInt32(ReflectionHelper.GetProperties<TWorkflowStateType>(
        BindingFlags.FlattenHierarchy |
        BindingFlags.Public | BindingFlags.Static)
                                            .Single(property => property.Name == inStringValue)
                                            .GetValue(null));
            }
            catch (ArgumentNullException ex)
            {
                throw ExceptionFactory.GetNewWorkflowStateNotFoundException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw ExceptionFactory.GetNewWorkflowStateNotFoundException(ex);
            }

            return result;
        }

        #endregion
    }
}