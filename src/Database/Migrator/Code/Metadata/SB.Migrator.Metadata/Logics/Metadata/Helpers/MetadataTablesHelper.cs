using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions;
using SB.Migrator.Metadata.Logics.Metadata.Models;

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
        public static List<AssemblyMetadata> Assemblies { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        static MetadataTablesHelper()
        {
            InitializeAssemblies();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitializeAssemblies()
        {
            Assemblies = new List<AssemblyMetadata>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            assemblies.ForEach(InitializeAssembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        private static void InitializeAssembly(Assembly assembly)
        {
            var attr = assembly.GetCustomAttribute<MigrateAttribute>();
            if (attr == null)
                return;

            var metadata = new AssemblyMetadata(attr.Name, attr.Version, assembly);
            metadata.BeforeActualizationScripts = MetadataScriptsHelper.GetBeforeActualizationScripts(assembly);
            metadata.BeforeActualizationScripts.ForEach(f=>f.MigrateName = attr.Name);

            metadata.AfterActualizationScripts = MetadataScriptsHelper.GetAfterActualizationScripts(assembly);
            metadata.AfterActualizationScripts.ForEach(f => f.MigrateName = attr.Name);

            Assemblies.Add(metadata);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ScriptMetadata> GetBeforeActualizationScripts()
        {
            return Assemblies.SelectMany(s => s.BeforeActualizationScripts).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ScriptMetadata> GetAfterActualizationScripts()
        {
            return Assemblies.SelectMany(s => s.AfterActualizationScripts).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetTableTypes()
        {
            var types = Assemblies.SelectMany(s => s.Assembly.GetTypes());
            return types.ToList(w => w.IsClass && !w.IsAbstract && w.IsHasAttribute<TableAttribute>());
        }
    }
}
