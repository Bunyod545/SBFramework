using System;
using SB.Migrator;
using SB.Migrator.Metadata;
using SB.Migrator.MySql;

[assembly: BeforeActualization("BeforeActualizationScripts.resources")]
[assembly: Migrate("MetadataPostgresMigration", "1.0.0.24")]
[assembly: AfterActualization("AfterActualizationScripts.resources")]

namespace MetadataMySqlMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "Server=localhost;Database=TestMetadataMigrator;Uid=root;Pwd=Formula1;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TableAttribute.DefaultSchema = "testmetadatamigrator";

            MigrateManager.Create(ConnectionString)
                .UseMySqlServerDatabase()
                .UseMetadataManager()
                .Migrate();

            Console.WriteLine("Migrate success");
            Console.ReadLine();
        }
    }
}
