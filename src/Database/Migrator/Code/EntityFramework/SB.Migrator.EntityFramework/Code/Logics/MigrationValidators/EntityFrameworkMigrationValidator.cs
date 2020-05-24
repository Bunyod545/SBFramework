using SB.Migrator.Logics.ServiceContainers;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityFrameworkMigrationValidator : DefaultMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public EntityFrameworkMigrationValidator(IMigrateServicesContainer container) : base(container)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsActual()
        {
            return false;
        }
    }
}
