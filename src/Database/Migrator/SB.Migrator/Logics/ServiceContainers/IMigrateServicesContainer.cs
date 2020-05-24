using System;

namespace SB.Migrator.Logics.ServiceContainers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMigrateServicesContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void RegisterTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="lifeCycle"></param>
        void Register<TService, TImplementation>(MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton) where TService : class where TImplementation : class, TService;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        void RegisterTransient<TService>() where TService : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="lifeCycle"></param>
        void Register<TService>(MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton) where TService : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        void RegisterTransient(Type serviceType, Type implementationType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifeCycle"></param>
        void Register(Type serviceType, Type implementationType, MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="implementationObj"></param>
        void Register<TService>(TService implementationObj);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService GetService<TService>() where TService : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object GetService(Type serviceType);
    }
}