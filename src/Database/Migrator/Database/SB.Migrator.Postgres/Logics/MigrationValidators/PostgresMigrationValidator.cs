namespace SB.Migrator.Postgres.Logics.MigrationValidators
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresMigrationValidator : DefaultMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public PostgresMigrationValidator(MigrateManager migrateManager) : base(migrateManager)
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
