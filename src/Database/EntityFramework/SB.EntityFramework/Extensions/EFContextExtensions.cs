using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SB.EntityFramework.Context
{
    /// <summary>
    /// 
    /// </summary>
    public static class EFContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<object> ModifiedObjects(this EFContext context)
        {
            return context.ChangeTracker
                          .Entries()
                          .Where(w => w.State == EntityState.Modified)
                          .Select(s => s.Entity).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<object> AddedObjects(this EFContext context)
        {
            return context.ChangeTracker
                .Entries()
                .Where(w => w.State == EntityState.Added)
                .Select(s => s.Entity).ToList();
        }
    }
}
