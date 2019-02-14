using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public static class MetadataTablesHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Assembly> Assemblies { get; }

        /// <summary>
        /// 
        /// </summary>
        public static List<Assembly> SafeAssemblies =>
            Assemblies.Any() ?
                Assemblies : 
                AppDomain.CurrentDomain.GetAssemblies().ToList();

        /// <summary>
        /// 
        /// </summary>
        static MetadataTablesHelper()
        {
            Assemblies = new List<Assembly>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        public static void AddAssembly(Assembly assembly)
        {
            Assemblies.Add(assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetTableTypes()
        {
            var types = SafeAssemblies.SelectMany(s => s.GetTypes());
            return types.ToList(w => w.IsClass && !w.IsAbstract && w.IsHasAttribute<TableAttribute>());
        }
    }
}
