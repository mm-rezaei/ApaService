using ApaService.Framework.Bol.Constants;
using ApaService.Framework.Bol.Cores.Factories.Services;
using ApaService.Framework.IBol.Cores.Services;

namespace ApaService.Framework.Bol.Factories.Services
{
    public sealed class ServiceFactory : ApasServiceFactoryBase<ApaServiceFrameworkBolConstant>
    {
        #region Constructors

        private ServiceFactory()
        {

        }

        #endregion

        #region Private Fields

        private static ServiceFactory _Instance;

        #endregion

        #region Protected Properties

        protected override string ServiceAssemblyName
        {
            get { return Assistant.ConstantValues.ServiceAssemblyName; }
        }

        #endregion

        #region Public Properties

        public static ServiceFactory Instance
        {
            get { return _Instance ?? (_Instance = new ServiceFactory()); }
        }

        #endregion

        #region Public Methods

        public override IApasService<TDataModelType> CreateService<TDataModelType>(object inContextScope)
        {
            var instance = CreateService(typeof(TDataModelType), inContextScope);

            var result = Assistant.Convertion.GetCastValue<IApasService<TDataModelType>>(instance);

            return result;
        }

        public override TServiceInterfaceType CreateService<TServiceInterfaceType, TDataModelType>(object inContextScope)
        {
            var instance = CreateService(typeof(TDataModelType), inContextScope);

            var result = Assistant.Convertion.GetCastValue<TServiceInterfaceType>(instance);

            return result;
        }

        #endregion
    }
}
