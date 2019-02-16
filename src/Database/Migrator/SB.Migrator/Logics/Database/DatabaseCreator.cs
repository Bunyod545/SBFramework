namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DatabaseCreator : IDatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        protected DatabaseCreator(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDatabaseExists();

        /// <summary>
        /// 
        /// </summary>
        public abstract void CreateDatabase();
    }
}
