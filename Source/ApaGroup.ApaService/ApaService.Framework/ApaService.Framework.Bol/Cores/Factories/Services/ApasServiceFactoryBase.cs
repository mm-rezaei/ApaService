using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Factory.Cores.Services;
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;
using ApaService.Framework.IBol.Cores.Services;

namespace ApaService.Framework.Bol.Cores.Factories.Services
{
    public abstract class ApasServiceFactoryBase<TConstantType> : ServiceFactoryBase<TConstantType>
        where TConstantType : ConstantBase, new()
    {
        #region Public Methods

        public abstract IApasService<TDataModelType> CreateService<TDataModelType>(object inContextScope)
            where TDataModelType : IApasDataModel;

        public abstract TServiceInterfaceType CreateService<TServiceInterfaceType, TDataModelType>(object inContextScope)
            where TServiceInterfaceType : IApasService<TDataModelType>
            where TDataModelType : IApasDataModel;

        #endregion
    }
}
