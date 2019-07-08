using EFPostgresMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework;

namespace EFPostgresMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SBMigration]
    public class DataContext : DbContext
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
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Program.ConnectionString);
        }
    }
}
