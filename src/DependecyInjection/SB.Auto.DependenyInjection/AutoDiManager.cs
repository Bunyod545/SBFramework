using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoDIManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<AutoDependencyInjectionInfo> GetServices()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var types = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(w =>
                       w.IsClass &&
                      !w.IsAbstract &&
                      !w.IsSealed &&
                       w.GetCustomAttribute<ServiceAttribute>() != null)
                .ToList();

            return types.Select(f => GetService(f)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private static AutoDependencyInjectionInfo GetService(Type type)
        {
            var attr = type.GetCustomAttribute<ServiceAttribute>();
            var interfaces = type.GetInterfaces().ToList();
            var baseType = type.BaseType;

            var info = new AutoDependencyInjectionInfo();
            info.ServiceType = type;
            info.LifeCycle = attr.LifeCycle;
            interfaces.ForEach(info.BaseTypes.Add);

            if (baseType != typeof(object))
                info.BaseTypes.Add(baseType);

            info.BaseTypes.Add(type);
            return info;
        }
    }
}
