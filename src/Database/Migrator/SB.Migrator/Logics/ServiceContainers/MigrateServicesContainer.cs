using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SB.Migrator.Logics.ServiceContainers
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrateServicesContainer : IMigrateServicesContainer
    {
        /// <summary>
        /// 
        /// </summary>
        protected WindsorContainer Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MigrateServicesContainer()
        {
            Container = new WindsorContainer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public void RegisterTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            Register<TService, TImplementation>(MigrateServiceLifeCycle.Transient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="lifeCycle"></param>
        public void Register<TService, TImplementation>(MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton) where TService : class where TImplementation : class, TService
        {
            Register(typeof(TService), typeof(TImplementation), lifeCycle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public void RegisterTransient<TService>() where TService : class
        {
            Register<TService>(MigrateServiceLifeCycle.Transient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="lifeCycle"></param>
        public void Register<TService>(MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton) where TService : class
        {
            Register(typeof(TService), typeof(TService), lifeCycle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            Register(serviceType, implementationType, MigrateServiceLifeCycle.Transient);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifeCycle"></param>
        public void Register(Type serviceType, Type implementationType, MigrateServiceLifeCycle lifeCycle = MigrateServiceLifeCycle.Singleton)
        {
            var componentRegistration = Component.For(serviceType).ImplementedBy(implementationType).IsDefault();
            if (lifeCycle == MigrateServiceLifeCycle.Singleton)
                componentRegistration = componentRegistration.LifestyleSingleton();

            if (lifeCycle == MigrateServiceLifeCycle.Transient)
                componentRegistration = componentRegistration.LifestyleTransient();

            Container.Register(componentRegistration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="implementationObj"></param>
        public void Register<TService>(TService implementationObj)
        {
            Container.Register(Component.For(typeof(TService)).Instance(implementationObj).LifestyleSingleton().IsDefault());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public TService GetService<TService>() where TService : class
        {
            return (TService)GetService(typeof(TService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            if (!Container.Kernel.HasComponent(serviceType))
                return null;

            return Container.Resolve(serviceType);
        }
    }
}
