using ApaGroup.Framework.Bol.Cores.ServiceTemplates;
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;

namespace ApaService.Framework.Bol.Cores.ServiceTemplates
{
    public abstract class ApasServiceTemplateBase<TDataModelType> : ServiceTemplateEmpty<TDataModelType>
        where TDataModelType : class, IApasDataModel, new()
    {
    }
}
