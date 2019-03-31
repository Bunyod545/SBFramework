using SB.Migrator;
using SB.Migrator.EntityFramework.Logics.Code.Extensions;
using SB.Migrator.SqlServer.Logics.Database.Extensions;

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
            MigrateManager.Create(ConnectionString)
                .UseSqlServerDatabase()
                .UseEfCodeTablesManager()
                .Migrate();
        }
    }
}
