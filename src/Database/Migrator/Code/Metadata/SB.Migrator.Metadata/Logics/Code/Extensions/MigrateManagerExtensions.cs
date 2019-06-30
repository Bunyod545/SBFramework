namespace SB.Migrator.Metadata.Logics.Code.Extensions
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
        public static MigrateManager UseMetadataManager(this MigrateManager migrateManager)
        {
            migrateManager.CodeTablesManager = new MetadataCodeTablesManager(migrateManager);
            return migrateManager;
        }
    }
}
