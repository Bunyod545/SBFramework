using System.Collections.Generic;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DatabaseTablesManager : IDatabaseTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public IColumnTypeMappingSource ColumnTypeMappingSource { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string DefaultSchema { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        protected DatabaseTablesManager(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<TableInfo> GetTableInfos();
    }
}
