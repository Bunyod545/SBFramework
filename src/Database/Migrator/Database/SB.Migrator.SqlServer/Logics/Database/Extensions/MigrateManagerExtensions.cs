namespace SB.Migrator.SqlServer.Logics.Database.Extensions
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
        public static MigrateManager UseSqlServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager(migrateManager);
            return migrateManager;
        }
    }
}
