using System;
using ApaGroup.Framework.Basis.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class WorkflowPropertyAttribute : AttributeBase
    {
        #region Constructors

        public WorkflowPropertyAttribute(string inWorkflowPropertyName)
            : this(inWorkflowPropertyName, false)
        {
        }

        public WorkflowPropertyAttribute(string inWorkflowPropertyName, bool inSaveOtherChanges)
        {
            WorkflowPropertyName = inWorkflowPropertyName;

            SaveOtherChanges = inSaveOtherChanges;
        }

        #endregion

        #region Public Properties

        public string WorkflowPropertyName { get; private set; }

        public bool SaveOtherChanges { get; private set; }

        #endregion
    }
}