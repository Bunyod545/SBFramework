using System.Linq;
using SB.Migrator.Logics.ServiceContainers;

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
        /// <param name="container"></param>
        /// <param name="metadataManager"></param>
        public MetadataMigrationValidator(IMigrateServicesContainer container, MetadataManager metadataManager) : base(container)
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
