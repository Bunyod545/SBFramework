using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.Database;

namespace SB.Migrator.EntityFramework.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSqlServerMigrateManager : MigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public EFSqlServerMigrateManager()
        {
            CodeTablesManager = new EFSqlCodeTablesManager();
            DatabaseTablesManager = new SqlDatabaseTablesManager();
            DatabaseCommandManager = new DatabaseCommandManager();
        }
    }
}
