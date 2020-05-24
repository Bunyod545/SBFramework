namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="migrateManager"></param>
    public delegate void MigrateBeginHandler(IMigrateManager migrateManager);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="migrateManager"></param>
    public delegate void MigrateEndHandler(IMigrateManager migrateManager);

    /// <summary>
    /// 
    /// </summary>
    public partial interface IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        event MigrateBeginHandler MigrateBegin;

        /// <summary>
        /// 
        /// </summary>
        event MigrateEndHandler MigrateEnd;
    }
}
