using EFSqlMigrationTestConsole.Contexts;
using EFSqlMigrationTestConsole.Contexts.Tables;
using SB.EntityFramework.Context;
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
            MultipleContextTest();
            return;

            MigrateHelper.ConnectionString = ConnectionString;

            var migrateManager = new MigrateManager();
            migrateManager.CodeTablesManager = new EFCodeTablesManager();
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager();
            migrateManager.DatabaseCommandManager = new DatabaseCommandManager();
            migrateManager.DatabaseCommandManager.UseSqlCommands();

            migrateManager.Migrate();
        }

        /// <summary>
        /// 
        /// </summary>
        static void MultipleContextTest()
        {
            var country = new Country();
            country.Name = "Uzb";

            var context = new SqlContext();
            var countryTable = context.GetTable<Country>();
            countryTable.Add(country);
            context.SaveChanges();


            var tashkentCity = new City();
            tashkentCity.Owner = country;
            tashkentCity.Name = "Tashkent city";

            var cities = context.GetTable<City>();
            cities.Add(tashkentCity);
            context.SaveChanges();
        }
    }
}
