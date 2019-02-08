using Microsoft.EntityFrameworkCore;
using SB.EntityFramework;

namespace SB.Common.Test.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class SBSystemTestContext : SBSystemContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(SBSystemTestContext));
        }
    }
}
