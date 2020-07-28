using SB.Migrator.Logics.Code;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrateManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MigrateManager UseEfCodeTablesManager(this MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.Register<ICodeTablesManager, EfCodeTablesManager>();
            migrateManager.ServicesContainer.Register<IMigrateValidator, EntityFrameworkMigrationValidator>();
            migrateManager.ServicesContainer.Register<ITableFinder, TableFinder>();

            migrateManager.UseSafeMode();
            return migrateManager;
        }
    }
}
