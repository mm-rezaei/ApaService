using System.Collections.Generic;
using ApaGroup.Framework.Dal.DataStructure.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    public sealed class ContainValidationRuleAttribute : ValidationRuleAttributeBase
    {
        #region Constructors

        public ContainValidationRuleAttribute(params object[] inContainList)
        {
            ContainList = inContainList;
        }

        #endregion

        #region Private Properties

        private IList<object> ContainList { get; set; }

        #endregion

        #region Public Methods

        public override bool IsValid(object inObject)
        {
            var result = ContainList.Contains(inObject);

            return result;
        }

        #endregion
    }
}