using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        ICodeTablesManager CodeTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseCommandManager DatabaseCommandManager { get; }

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
