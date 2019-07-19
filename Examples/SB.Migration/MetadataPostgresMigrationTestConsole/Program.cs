using System;
using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.Metadata.Logics.Code.Extensions;
using SB.Migrator.Postgres.Logics.Database.Extensions;

[assembly: BeforeActualization("BeforeActualizationScripts.resources")]
[assembly: Migrate("MetadataPostgresMigration", "1.0.0.23")]
[assembly: AfterActualization("AfterActualizationScripts.resources")]

namespace MetadataPostgresMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=TestMetadataMigrator;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MigrateManager.Create(ConnectionString)
                .UsePostgresServerDatabase()
                .UseMetadataManager()
                .Migrate();

            Console.WriteLine("Migrate success");
            Console.ReadLine();
        }
    }
}
