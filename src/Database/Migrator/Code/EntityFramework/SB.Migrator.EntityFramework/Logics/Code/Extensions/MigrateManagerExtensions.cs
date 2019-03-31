namespace SB.Migrator.EntityFramework.Logics.Code.Extensions
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
            migrateManager.CodeTablesManager = new EFCodeTablesManager(migrateManager);
            return migrateManager;
        }
    }
}
