using SB.Migrator.Logics.Code;
using SB.Migrator.Metadata.Logics.Code.Logics.MigrationValidators;

namespace SB.Migrator.Metadata
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
            migrateManager.ServicesContainer.Register<ICodeTablesManager, MetadataCodeTablesManager>();
            migrateManager.ServicesContainer.Register<IMigrateValidator, MetadataMigrationValidator>();
            migrateManager.ServicesContainer.Register<MetadataManager>();

            migrateManager.UseSafeMode();
            return migrateManager;
        }
    }
}
