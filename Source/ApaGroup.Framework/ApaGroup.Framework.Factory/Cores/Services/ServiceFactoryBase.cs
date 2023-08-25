using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Locks;
using ApaGroup.Framework.Bol.Attributes;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace ApaGroup.Framework.Factory.Cores.Services
{
    public abstract class ServiceFactoryBase<TConstantType> : ApaGroupBase<TConstantType>
        where TConstantType : ConstantBase, new()
    {
        #region Private Fields

        private static readonly InternalLock _InternalLock = new InternalLock();

        private readonly ConcurrentDictionary<Type, ServiceTypeInformation> _ServiceTypeCache = new ConcurrentDictionary<Type, ServiceTypeInformation>(10, 5000);

        private Assembly _ServiceAssembly;

        #endregion

        #region Private Properties

        private static InternalLock InternalLock
        {
            get { return _InternalLock; }
        }

        private ConcurrentDictionary<Type, ServiceTypeInformation> ServiceTypeCache
        {
            get { return _ServiceTypeCache; }
        }

        #endregion

        #region Private Methods

        private static void CheckDataModelAbstraction(Type inDataModelType)
        {
            if (inDataModelType.IsAbstract)
            {
                throw ExceptionFactory.GetNewFactoryException(null,
                    "The data model, '" + inDataModelType + "', is abstract.");
            }
        }

        private ServiceTypeInformation GetServiceTypeInformation(Type inDataModelType)
        {
            if (_ServiceAssembly == null)
            {
                lock (InternalLock)
                {
                    if (_ServiceAssembly == null)
                    {
                        #region Load Assembly

                        try
                        {
                            _ServiceAssembly = Assembly.Load(ServiceAssemblyName);
                        }
                        catch (Exception ex)
                        {
                            throw ExceptionFactory.GetNewFactoryException(ex, "");
                        }

                        #endregion

                        #region Add Implemented Service To The Service Type Cache

                        foreach (var type in _ServiceAssembly.GetTypes())
                        {
                            var serviceAttribute =
                                Assistant.Reflection.GetCustomAttributes<ServiceAttribute>(type, false)
                                    .FirstOrDefault();

                            if (serviceAttribute != null)
                            {
                                var serviceTypeInformation =
                                    new ServiceTypeInformation(type);

                                if (
                                    !ServiceTypeCache.TryAdd(serviceAttribute.DataModelType,
                                        serviceTypeInformation))
                                {
                                    throw ExceptionFactory.GetNewFactoryException(null,
                                        "The service of '" + serviceAttribute.DataModelType +
                                        "' could not add to the service cache.");
                                }
                            }
                        }

                        #endregion
                    }
                }
            }

            if (!ServiceTypeCache.ContainsKey(inDataModelType))
            {
                throw ExceptionFactory.GetNewFactoryException(null, "The service of '" + inDataModelType + "' does not exist");
            }

            return ServiceTypeCache[inDataModelType];
        }

        #endregion

        #region Private Class

        private class ServiceTypeInformation
        {
            #region Constructors

            public ServiceTypeInformation(Type inImplementedServiceType)
            {
                ServiceType = inImplementedServiceType;
            }

            #endregion

            #region Private Properties

            private Type ServiceType { get; set; }

            #endregion

            #region Public Methods

            public object GetServiceInstance(object inContextScope)
            {
                var result = Assistant.Reflection.GetNewInstance(ServiceType, inContextScope);

                return result;
            }

            #endregion
        }

        #endregion

        #region Protected Properties

        protected abstract string ServiceAssemblyName { get; }

        #endregion

        #region Public Methods

        public object CreateService(Type inTDataModelType, object inContextScope)
        {
            CheckDataModelAbstraction(inTDataModelType);

            return GetServiceTypeInformation(inTDataModelType).GetServiceInstance(inContextScope);
        }

        #endregion
    }
}
