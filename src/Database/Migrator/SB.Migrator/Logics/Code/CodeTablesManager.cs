using System.Collections.Generic;
using SB.Migrator.Models;

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
        public MigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        protected CodeTablesManager(MigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<TableInfo> GetTableInfos();
    }
}
