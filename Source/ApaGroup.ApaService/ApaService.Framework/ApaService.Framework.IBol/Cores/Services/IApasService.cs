using ApaGroup.Framework.IBol.Cores.Services;
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;

namespace ApaService.Framework.IBol.Cores.Services
{
    public interface IApasService<TDataModelType> : IService<TDataModelType>
        where TDataModelType : IApasDataModel
    {
    }
}
