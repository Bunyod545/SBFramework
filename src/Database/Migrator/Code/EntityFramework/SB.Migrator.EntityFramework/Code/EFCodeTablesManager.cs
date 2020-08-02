using System.Collections.Generic;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistories;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EfCodeTablesManager : CodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        public ITableFinder TableFinder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDatabaseTablesManager DatabaseTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public EfCodeTablesManager(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            TableFinder = MigrateManager.ServicesContainer.GetService<ITableFinder>();
            DatabaseTablesManager = MigrateManager.ServicesContainer.GetService<IDatabaseTablesManager>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<TableInfo> GetTableInfos()
        {
            return TableFinder.GetTableInfos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<MigrationVersionInfo> GetMigrationVersionInfos()
        {
            return TableFinder.GetMigrationVersionInfos();
        }
    }
}
