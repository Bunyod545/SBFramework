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
        /// <returns></returns>
        public abstract bool IsDatabaseExists();

        /// <summary>
        /// 
        /// </summary>
        public abstract void CreateDatabase();
    }
}
