namespace SB.Migrator.MySql
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
        public static MigrateManager UseMySqlServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.DatabaseTablesManager = new MySqlDatabaseTablesManager(migrateManager);
            return migrateManager;
        }
    }
}
