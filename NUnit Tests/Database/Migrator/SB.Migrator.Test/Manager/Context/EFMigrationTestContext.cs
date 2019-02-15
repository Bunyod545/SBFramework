using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Test.Logics.SbTypes.Context.Tables;

namespace SB.EntityFramework.Test.Logics.SbTypes.Context
{
    /// <summary>
    /// 
    /// </summary>
    [SBMigration]
    public class EFMigrationTestContext : SBSystemContext
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
