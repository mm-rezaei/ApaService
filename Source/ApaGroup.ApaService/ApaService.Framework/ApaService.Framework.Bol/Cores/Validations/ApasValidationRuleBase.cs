using ApaGroup.Framework.Bol.Cores.Validations;
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;

namespace ApaService.Framework.Bol.Cores.Validations
{
    public abstract class ApasValidationRuleBase<TDataModelType> : ValidationRuleBase<TDataModelType>
        where TDataModelType : IApasDataModel
    {
    }
}
