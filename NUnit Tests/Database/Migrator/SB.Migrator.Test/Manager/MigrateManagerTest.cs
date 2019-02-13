using System.Reflection;
using NUnit.Framework;
using SB.EntityFramework;
using SB.Migrator.EntityFramework;
using SB.Migrator.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer;
using SB.Migrator.SqlServer.Logics.Database;

namespace SB.Migrator.Test.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrateManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Migrate()
        {
            MigrateHelper.ConnectionString = "Server=MWI_91\\SQLSERVER2014;Database=TestEF;Trusted_Connection=True;";
            TableFinder.AddAssembly(Assembly.GetExecutingAssembly());

            var migrateManager = new MigrateManager();
            migrateManager.CodeTablesManager = new EFCodeTablesManager();
            migrateManager.DatabaseTablesManager = new SqlDatabaseTablesManager();
            migrateManager.DatabaseCommandManager = new DatabaseCommandManager();

            migrateManager.DatabaseCommandManager.UseSqlCommands();
            migrateManager.Migrate();
        }
    }
}