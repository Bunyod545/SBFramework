using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;

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
    public interface IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        event MigrateBeginHandler MigrateBegin;

        /// <summary>
        /// 
        /// </summary>
        event MigrateEndHandler MigrateEnd;

        /// <summary>
        /// 
        /// </summary>
        IMigrateValidator Validator { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        ICodeTablesManager CodeTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseTablesManager DatabaseTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseCommandManager DatabaseCommandManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseCreator DatabaseCreator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IMigrationsHistoryRepository MigrationsHistoryRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// 
        /// </summary>
        void Migrate();
    }
}
