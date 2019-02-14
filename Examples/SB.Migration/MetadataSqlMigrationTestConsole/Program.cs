using System.Reflection;
using SB.Migrator;
using SB.Migrator.Helpers;
using SB.Migrator.Metadata;
using SB.Migrator.SqlServer.Logics.Database;

namespace MetadataSqlMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "Server=.\\SQLSERVER2014;Database=TestEFSql;Trusted_Connection=True;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            MigrateHelper.ConnectionString = ConnectionString;

            var migrateManager = new MigrateManager();
            migrateManager.CodeTablesManager = new MetadataCodeTablesManager(migrateManager);
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager(migrateManager);

            migrateManager.Migrate();
        }
    }
}
