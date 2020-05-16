using System.Collections.Generic;
using System.Reflection;
using SB.Migrator.Metadata.Logics.Metadata.Models;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class AssemblyMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public string MigrateName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MigrateVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ScriptMetadata> BeforeActualizationScripts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ScriptMetadata> AfterActualizationScripts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateVersion"></param>
        /// <param name="migrateName"></param>
        /// <param name="assembly"></param>
        public AssemblyMetadata(string migrateName, string migrateVersion, Assembly assembly)
        {
            MigrateName = migrateName;
            MigrateVersion = migrateVersion;
            Assembly = assembly;
        }
    }
}
