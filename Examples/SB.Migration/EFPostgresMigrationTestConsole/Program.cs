using System;
using SB.Migrator;
using SB.Migrator.EntityFramework.Logics.Code.Extensions;
using SB.Migrator.Postgres.Logics.Database.Extensions;

namespace EFPostgresMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=TestEfMigrator;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MigrateManager.Create(ConnectionString)
                .UsePostgresServerDatabase()
                .UseEfCodeTablesManager()
                .Migrate();

            Console.WriteLine("Migrate success");
            Console.ReadLine();
        }
    }
}
