using SB.Migrator;
using SB.Migrator.EntityFramework;
using SB.Migrator.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer;
using SB.Migrator.SqlServer.Logics.Database;

namespace EFSqlMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "Server=.;Database=TestEFSql;Trusted_Connection=True;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MigrateHelper.ConnectionString = ConnectionString;

            var migrateManager = new MigrateManager();
            migrateManager.CodeTablesManager = new EFCodeTablesManager();
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager();
            migrateManager.DatabaseCommandManager = new DatabaseCommandManager();
            migrateManager.DatabaseCommandManager.UseSqlCommands();

            migrateManager.Migrate();
        }
    }
}
