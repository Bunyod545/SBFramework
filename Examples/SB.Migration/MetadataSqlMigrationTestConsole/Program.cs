using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.SqlServer;

[assembly: BeforeActualization("BeforeActualizationScripts.resources")]
[assembly: Migrate("MetadataSqlMigration", "1.0.0.3")]
[assembly: AfterActualization("AfterActualizationScripts.resources")]

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
        public const string ConnectionString = "Server=.;Database=TestMetadataMigrator;Trusted_Connection=True;";

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
