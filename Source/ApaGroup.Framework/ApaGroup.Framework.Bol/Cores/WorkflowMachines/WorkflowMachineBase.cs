using System.Collections.Generic;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.Bol.Cores.WorkFlowMachines
{
    public abstract class WorkflowMachineBase
    {
        #region Constructors

        protected WorkflowMachineBase()
            : this(WorkflowAction.Save, WorkflowAction.Delete)
        {
        }

        protected WorkflowMachineBase(params WorkflowAction[] inAcceptableActions)
        {
            if (inAcceptableActions != null)
            {
                AcceptableActions = new List<WorkflowAction>();

                foreach (var action in inAcceptableActions)
                {
                    AcceptableActions.Add(action);
                }
            }
        }

        #endregion

        #region Private Properties

        private List<WorkflowAction> AcceptableActions { get; set; }

        #endregion

        #region Protected Methods

        protected void AddActionToList(IList<WorkflowAction> inActions, WorkflowAction inAction)
        {
            if (inActions != null && !inActions.Contains(inAction) &&
                (AcceptableActions == null || AcceptableActions.Contains(inAction)))
            {
                inActions.Add(inAction);
            }
        }

        #endregion

        #region Public Methods

        public virtual IList<WorkflowAction> GetNextActions(WorkflowState inCurrentState)
        {
            IList<WorkflowAction> result = new List<WorkflowAction>();

            if (inCurrentState == WorkflowStateBase.UnSaved)
            {
                AddActionToList(result, WorkflowActionBase.Save);
            }
            else if (inCurrentState == WorkflowStateBase.None)
            {
                AddActionToList(result, WorkflowActionBase.Save);
                AddActionToList(result, WorkflowActionBase.Delete);
            }

            return result;
        }

        public virtual WorkflowState GetNextState(WorkflowState inCurrentState, WorkflowAction inAction)
        {
            var result = WorkflowStateBase.None;

            if (inCurrentState == WorkflowStateBase.UnSaved)
            {
                if (inAction == WorkflowActionBase.Save)
                {
                    result = WorkflowStateBase.None;
                }
            }
            else if (inCurrentState == WorkflowStateBase.None)
            {
                if (inAction == WorkflowActionBase.Save)
                {
                    result = WorkflowStateBase.None;
                }
                else if (inAction == WorkflowActionBase.Delete)
                {
                    result = WorkflowStateBase.Deleted;
                }
            }

            return result;
        }

        #endregion
    }
}