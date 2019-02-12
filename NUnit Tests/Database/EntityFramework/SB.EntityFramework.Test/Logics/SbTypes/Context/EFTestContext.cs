using System.Linq;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Test.Logics.SbTypes.Context.Tables;

namespace SB.EntityFramework.Test.Logics.SbTypes.Context
{
    /// <summary>
    /// 
    /// </summary>
    [SBMigration]
    public class EFTestContext : SBSystemContext
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
            optionsBuilder.UseInMemoryDatabase(nameof(EFTestContext));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Country>()
                .Property(sample => sample.Name)
                .HasColumnType("char(3)");
        }
    }
}
