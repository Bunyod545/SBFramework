using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Test.Logics.SbTypes.Context.Tables;
using SB.Migrator.EntityFramework;

namespace SB.EntityFramework.Test.Logics.SbTypes.Context
{
    /// <summary>
    /// 
    /// </summary>
    [SbMigration("1.0.0.0")]
    public class EFMigrationTestContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
