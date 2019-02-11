using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class SBMigrationManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Migrate()
        {
            var types = TableFinder.GetContextTypes();
            types.ForEach(InternalMigrate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        private static void InternalMigrate(Type contextType)
        {
            var attr = contextType.GetCustomAttribute<SBMigrationAttribute>();
            if (attr == null)
                return;

            if (contextType.IsAbstract)
                return;

            var context = Activator.CreateInstance(contextType) as EFContext;
            context?.Database.Migrate();
        }
    }
}
