using System.Collections.Generic;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistorys;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Logics.Code
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CodeTablesManager : ICodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        protected CodeTablesManager(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<ScriptInfo> GetBeforeActualizationScripts()
        {
            return new List<ScriptInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<ScriptInfo> GetAfterActualizationScripts()
        {
            return new List<ScriptInfo>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<TableInfo> GetTableInfos();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<MigrationVersionInfo> GetMigrationVersionInfos();
    }
}
