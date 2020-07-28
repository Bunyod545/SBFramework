using EFPostgresMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using SB.Migrator.EntityFramework;

namespace EFPostgresMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SbMigration("1.0.0.0")]
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
            modelBuilder.Entity<Country>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(u => u.DesignedName)
                .IsUnique();

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
