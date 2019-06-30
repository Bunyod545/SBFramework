namespace SB.Migrator.Postgres.Logics.Database.Extensions
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
        public static MigrateManager UsePostgresServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.DatabaseTablesManager = new PostgresDatabaseTablesManager(migrateManager);
            return migrateManager;
        }
    }
}
