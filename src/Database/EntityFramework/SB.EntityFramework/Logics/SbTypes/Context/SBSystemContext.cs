using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SBSystemContext : EFContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<SbType> SbTypes { get; set; }

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
