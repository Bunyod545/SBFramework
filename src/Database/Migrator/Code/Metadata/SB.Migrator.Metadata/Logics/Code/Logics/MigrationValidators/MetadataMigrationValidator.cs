using System.Linq;

namespace SB.Migrator.Metadata.Logics.Code.Logics.MigrationValidators
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataMigrationValidator : DefaultMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        public MetadataManager MetadataManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        /// <param name="metadataManager"></param>
        public MetadataMigrationValidator(MigrateManager migrateManager, MetadataManager metadataManager) : base(migrateManager)
        {
            MetadataManager = metadataManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsActual()
        {
            return !MetadataManager.Assemblies.Any();
        }
    }
}
