using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.SqlServer;

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
        public const string ConnectionString = "Server=.;Database=TestEFSql;Trusted_Connection=True;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var migrateManager = new MigrateManager(ConnectionString);
            migrateManager.CodeTablesManager = new MetadataCodeTablesManager(migrateManager);
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager(migrateManager);

            migrateManager.Migrate();
        }
    }
}
