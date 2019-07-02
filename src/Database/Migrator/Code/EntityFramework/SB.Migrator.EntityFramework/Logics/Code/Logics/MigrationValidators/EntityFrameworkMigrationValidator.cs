namespace SB.Migrator.EntityFramework.Logics.Code.Logics.MigrationValidators
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityFrameworkMigrationValidator : DefaultMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public EntityFrameworkMigrationValidator(MigrateManager migrateManager) : base(migrateManager)
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
