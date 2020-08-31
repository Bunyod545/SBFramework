using Autofac;
using System;
using System.Linq;

namespace SB.TelegramBot.Logics.TelegramBotDIContainers
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotServicesContainer
    {
        /// <summary>
        /// 
        /// </summary>
        private static ContainerBuilder _containerBuilder;

        /// <summary>
        /// 
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// 
        /// </summary>
        static TelegramBotServicesContainer()
        {
            _containerBuilder = new ContainerBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public static void AddScoped<TInterface, TImplement>() where TImplement : TInterface
        {
            _containerBuilder.RegisterType<TImplement>().As<TInterface>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public static void AddSingleton<TInterface, TImplement>() where TImplement : TInterface
        {
            _containerBuilder.RegisterType<TImplement>().As<TInterface>().SingleInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public static void AddTransient<TInterface, TImplement>() where TImplement : TInterface
        {
            _containerBuilder.RegisterType<TImplement>().As<TInterface>().InstancePerDependency();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            _container = _containerBuilder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsRegistered<T>()
        {
            return IsRegistered(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static bool IsRegistered(Type serviceType)
        {
            return _container.IsRegistered(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        public static TInterface GetService<TInterface>()
        {
            return _container.Resolve<TInterface>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        public static object GetService(Type type)
        {
            return _container.Resolve(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T CreateWithServices<T>()
        {
            return (T)CreateWithServices(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateWithServices(Type type)
        {
            var ctors = type.GetConstructors();
            if (ctors.Length == 0)
                throw new Exception($"Cannot find any public constructor for {type}");

            if (ctors.Length > 1)
                throw new Exception($"More public constructors for {type}");

            var ctor = ctors.FirstOrDefault();
            var ctorParamsInfos = ctor.GetParameters();

            var ctorParams = new object[ctorParamsInfos.Length];
            for (int index = 0; index < ctorParamsInfos.Length; index++)
            {
                var ctorParamInfo = ctorParamsInfos[index];
                ctorParams[index] = GetService(ctorParamInfo.ParameterType);
            }

            return Activator.CreateInstance(type, ctorParams);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Dispose()
        {
            _container.Dispose();
            _containerBuilder = null;
            _container = null;
        }
    }
}
