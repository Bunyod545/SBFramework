using EFSqlMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using SB.Migrator.EntityFramework;

namespace EFSqlMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SbMigration("1.0.0.0")]
    public class FirstDataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program.ConnectionString);
        }
    }
}
