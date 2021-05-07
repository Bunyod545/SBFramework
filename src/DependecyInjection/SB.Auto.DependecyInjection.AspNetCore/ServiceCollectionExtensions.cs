using SB.Auto.DependenyInjection;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void UseAutoDI(this IServiceCollection services)
        {
            var servicesInfos = AutoDIManager.GetServices();
            var transientServices = servicesInfos.Where(w => w.LifeCycle == ServiceLifeCycle.Transient).ToList();
            transientServices.ForEach(f => RegisterTransientService(services, f));

            var scopedServices = servicesInfos.Where(w => w.LifeCycle == ServiceLifeCycle.Scoped).ToList();
            scopedServices.ForEach(f => RegisterScopedService(services, f));

            var singletonServices = servicesInfos.Where(w => w.LifeCycle == ServiceLifeCycle.Singleton).ToList();
            singletonServices.ForEach(f => RegisterSingletonService(services, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="info"></param>
        private static void RegisterTransientService(IServiceCollection services, AutoDependencyInjectionInfo info)
        {
            info.BaseTypes.ForEach(baseType => services.AddTransient(baseType, info.ServiceType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="info"></param>
        private static void RegisterScopedService(IServiceCollection services, AutoDependencyInjectionInfo info)
        {
            info.BaseTypes.ForEach(baseType => services.AddScoped(baseType, info.ServiceType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="info"></param>
        private static void RegisterSingletonService(IServiceCollection services, AutoDependencyInjectionInfo info)
        {
            info.BaseTypes.ForEach(baseType => services.AddSingleton(baseType, info.ServiceType));
        }
    }
}
