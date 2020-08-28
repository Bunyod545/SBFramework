using Autofac;

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
        /// <typeparam name="TInterface"></typeparam>
        public static TInterface GetService<TInterface>()
        {
            return _container.Resolve<TInterface>();
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
