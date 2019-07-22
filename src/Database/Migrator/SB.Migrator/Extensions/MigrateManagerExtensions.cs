using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrateManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public static void UseSafeMode(this MigrateManager manager)
        {
            var services = manager?.DatabaseCommandManager?.CommandServices;
            if (services == null)
                return;

            services.Remove<IDropTableCommand>();
            services.Remove<IDropColumnCommand>();
            services.Remove<IDropUniqueKeyCommand>();
            services.Remove<IDropForeignKeyCommand>();
            services.Remove<IDropPrimaryKeyCommand>();
            services.Remove<IDropColumnDefaultValueCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="table"></param>
        public static void CorrectName(this IMigrateManager manager, TableInfo table)
        {
            manager?.NamingManager?.TableNamingManager?.Correct(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="column"></param>
        public static void CorrectName(this IMigrateManager manager, ColumnInfo column)
        {
            manager?.NamingManager?.ColumnNamingManager?.Correct(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="primaryKey"></param>
        public static void CorrectName(this IMigrateManager manager, PrimaryKeyInfo primaryKey)
        {
            manager?.NamingManager?.PrimaryKeyNamingManager?.Correct(primaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="foreignKey"></param>
        public static void CorrectName(this IMigrateManager manager, ForeignKeyInfo foreignKey)
        {
            manager?.NamingManager?.ForeignKeyNamingManager?.Correct(foreignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="uniqueKey"></param>
        public static void CorrectName(this IMigrateManager manager, UniqueKeyInfo uniqueKey)
        {
            manager?.NamingManager?.UniqueKeyNamingManager?.Correct(uniqueKey);
        }
    }
}
