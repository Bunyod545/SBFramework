using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;

namespace SB.EntityFramework.SqlServer.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlServerContext : EFContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<SbType> SbTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SbDatabase.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SbType>().HasAlternateKey(i => new { i.Prefix, i.Name }).HasName("IX_NameAndSchema");
            base.OnModelCreating(modelBuilder);
        }
    }
}
