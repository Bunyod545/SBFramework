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
    }
}
