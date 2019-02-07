using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SB.EntityFramework.SqlServer.Context;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.SqlServer.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlTestContext : SqlServerContext
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
            optionsBuilder.UseInMemoryDatabase(nameof(SqlTestContext));
        }
    }
}
