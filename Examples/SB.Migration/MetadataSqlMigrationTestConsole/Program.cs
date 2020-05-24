using System;
using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.SqlServer.Logics.Database.Extensions;

[assembly: BeforeActualization("BeforeActualizationScripts.resources")]
[assembly: Migrate("MetadataSqlMigration", "1.0.0.4")]
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
            MigrateManager.Create(ConnectionString)
                .UseSqlServerDatabase()
                .UseMetadataManager()
                .Migrate();

            Console.WriteLine("Migrate success");
            Console.ReadLine();
        }
    }
}
