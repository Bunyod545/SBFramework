using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.Metadata.Logics.Code.Extensions;
using SB.Migrator.SqlServer.Logics.Database.Extensions;

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
        public const string ConnectionString = "Server=User\\SQLEXPRESS;Database=TestMetadataMigrator;Trusted_Connection=True;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MigrateManager.Create(ConnectionString)
                .UseSqlServerDatabase()
                .UseMetadataManager()
                .Migrate();
        }
    }
}
