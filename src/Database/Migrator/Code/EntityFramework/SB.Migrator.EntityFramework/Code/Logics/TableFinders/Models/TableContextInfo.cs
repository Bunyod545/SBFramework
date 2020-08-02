using System;
using System.Collections.Generic;

namespace SB.Migrator.EntityFramework.Code.Logics.TableFinders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TableContextInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ContextType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Version MigrateVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Type> TableTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <param name="migrateVersion"></param>
        public TableContextInfo(Type contextType, string migrateVersion)
        {
            ContextType = contextType;
            MigrateVersion = new Version(migrateVersion);
            TableTypes = new List<Type>();
        }
    }
}
