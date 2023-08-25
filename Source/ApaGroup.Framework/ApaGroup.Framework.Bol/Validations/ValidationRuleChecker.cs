using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApaGroup.Framework.Basis.Cores.Systems;
using ApaGroup.Framework.Bol.Attributes;
using ApaGroup.Framework.Bol.Constants;
using ApaGroup.Framework.Bol.Cores.Validations;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Shared.Enumerations;

namespace ApaGroup.Framework.Bol.Validations
{
    internal class ValidationRuleChecker<TDataModelType, TValidationRuleType> :
        ApaGroupBase<ApaGroupFrameworkBolConstant>
        where TDataModelType : IDataModel
        where TValidationRuleType : ValidationRuleBase<TDataModelType>, new()
    {
        #region Private Fields

        private TValidationRuleType _Rules;

        #endregion

        #region Private Properties

        private TValidationRuleType Rules
        {
            get { return _Rules ?? (_Rules = new TValidationRuleType()); }
        }

        #endregion

        #region Private Methods

        private IEnumerable<MethodInfo> GetMethodsBySpesificRuleActionType(WorkflowAction inWorkflowAction)
        {
            return
                (from methodInfo in
                     Assistant.Reflection.GetMethods<TValidationRuleType>(BindingFlags.FlattenHierarchy |
                                                                          BindingFlags.Public)
                 let methodAttributes =
                     Assistant.Reflection.GetCustomAttributes<ValidationRuleCheckAttribute>(methodInfo, true)
                 let validationRuleCheckAttributes =
                     methodAttributes as IList<ValidationRuleCheckAttribute> ??
                     methodAttributes.ToList()
                 where validationRuleCheckAttributes.Count() != 0
                 let methodAttribute = validationRuleCheckAttributes.ElementAt(0)
                 where (methodAttribute.Action & inWorkflowAction) == inWorkflowAction
                 select methodInfo).ToList();
        }

        private IEnumerable<IValidationMessageDataObject> GetCheckedRuleResultBySpesificRuleActionType(
            WorkflowAction inWorkflowAction, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules, bool inCollectAllValidationMessage)
        {
            var result = Rules.CheckSpecialRules(inDataModel, inCollectAllValidationMessage);

            if (inCollectAllValidationMessage || !result.Any())
            {
                foreach (var message in Rules.CheckPropertiesRules(inDataModel, true))
                {
                    result.Add(message);

                    if (!inCollectAllValidationMessage)
                    {
                        break;
                    }
                }
            }

            if (inCollectAllValidationMessage || !result.Any())
            {
                foreach (var info in GetMethodsBySpesificRuleActionType(inWorkflowAction))
                {
                    foreach (var message in (IList<IValidationMessageDataObject>)info.Invoke(Rules, new[] { inWorkflowAction, inDataModel, inRelatedObjectsForCheckingRules }))
                    {
                        result.Add(message);

                        if (!inCollectAllValidationMessage)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region Public Methods

        public IEnumerable<IValidationMessageDataObject> CheckRules(WorkflowAction inWorkflowAction, TDataModelType inDataModel, object inRelatedObjectsForCheckingRules, bool inCollectAllValidationMessage)
        {
            var result = GetCheckedRuleResultBySpesificRuleActionType(inWorkflowAction, inDataModel, inRelatedObjectsForCheckingRules, inCollectAllValidationMessage);

            return result;
        }

        #endregion
    }
}