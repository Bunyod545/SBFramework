using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using SB.Migrator.EntityFramework.Code.Logics.TableFinders.Models;

namespace SB.Migrator.EntityFramework.Code.Logics.TableFinders.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TableContextFinderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TableContextInfo> GetContexts()
        {
            var types = GetContextTypes();
            return types.Select(GetMigrateContextType).Where(w => w != null).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<Type> GetContextTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes());

            return types.Where(w => typeof(DbContext).IsAssignableFrom(w)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        private static TableContextInfo GetMigrateContextType(Type contextType)
        {
            var attr = contextType?.GetCustomAttribute<SbMigrationAttribute>();
            if (attr == null || contextType.IsAbstract)
                return null;

            var tableTypes = GetContextTables(contextType);
            if (tableTypes.IsNullOrEmpty())
                return null;

            var info = new TableContextInfo(contextType, attr.Version);
            info.TableTypes = tableTypes;

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        private static List<Type> GetContextTables(Type contextType)
        {
            var props = contextType.GetProperties();
            var dbSetProps = props.Where(w =>
                w.PropertyType.IsGenericType &&
                typeof(DbSet<>).IsAssignableFrom(w.PropertyType.GetGenericTypeDefinition()));

            return dbSetProps.Select(s => s.PropertyType.GetGenericArguments().FirstOrDefault()).ToList();
        }
    }
}
