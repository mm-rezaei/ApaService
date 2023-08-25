using System;
using ApaGroup.Framework.Basis.Cores.Attributes;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.Bol.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ValidationRuleCheckAttribute : AttributeBase
    {
        #region Constructors

        public ValidationRuleCheckAttribute(WorkflowAction inRuleAction)
        {
            Action = inRuleAction;
        }

        #endregion

        #region Public Properties

        public WorkflowAction Action { get; private set; }

        #endregion
    }
}