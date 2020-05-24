using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Logics.DatabaseCommandServices;
using SB.Migrator.Logics.NamingManagers;
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
        public static void UseUnsafeMode(this IMigrateManager manager)
        {
            var servicesContainer = manager?.ServicesContainer;
            var commandsService = servicesContainer?.GetService<IDatabaseCommandsService>();
            if (commandsService == null)
                return;

            commandsService.Clear();
            commandsService.Register<ICreateColumnDefaultValueCommand>();
            commandsService.Register<IDropColumnDefaultValueCommand>();
            commandsService.Register<ICreateColumnCommand>();
            commandsService.Register<IDropColumnCommand>();
            commandsService.Register<IRenameColumnCommand>();
            commandsService.Register<ICreateForeignKeyCommand>();
            commandsService.Register<IDropForeignKeyCommand>();
            commandsService.Register<ICreatePrimaryKeyCommand>();
            commandsService.Register<IDropPrimaryKeyCommand>();
            commandsService.Register<ICreateUniqueKeyCommand>();
            commandsService.Register<IDropUniqueKeyCommand>();
            commandsService.Register<IAfterActualizationScriptCommand>();
            commandsService.Register<IBeforeActualizationScriptCommand>();
            commandsService.Register<ICreateTableCommand>();
            commandsService.Register<IDropTableCommand>();
            commandsService.Register<IRenameTableCommand>();
            commandsService.Register<ITableValuesCommand>();

        }

        /// <summary>
        /// 
        /// </summary>
        public static void UseSafeMode(this IMigrateManager manager)
        {
            var servicesContainer = manager?.ServicesContainer;
            var commandsService = servicesContainer?.GetService<IDatabaseCommandsService>();
            if (commandsService == null)
                return;

            commandsService.Clear();
            commandsService.Register<ICreateColumnDefaultValueCommand>();
            commandsService.Register<ICreateColumnCommand>();
            commandsService.Register<IRenameColumnCommand>();
            commandsService.Register<ICreateForeignKeyCommand>();
            commandsService.Register<ICreatePrimaryKeyCommand>();
            commandsService.Register<ICreateUniqueKeyCommand>();
            commandsService.Register<IAfterActualizationScriptCommand>();
            commandsService.Register<IBeforeActualizationScriptCommand>();
            commandsService.Register<ICreateTableCommand>();
            commandsService.Register<IRenameTableCommand>();
            commandsService.Register<ITableValuesCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="table"></param>
        public static void CorrectName(this IMigrateManager manager, TableInfo table)
        {
            manager?.GetNamingManager()?.TableNamingManager?.Correct(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="column"></param>
        public static void CorrectName(this IMigrateManager manager, ColumnInfo column)
        {
            manager?.GetNamingManager()?.ColumnNamingManager?.Correct(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="primaryKey"></param>
        public static void CorrectName(this IMigrateManager manager, PrimaryKeyInfo primaryKey)
        {
            manager?.GetNamingManager()?.PrimaryKeyNamingManager?.Correct(primaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="foreignKey"></param>
        public static void CorrectName(this IMigrateManager manager, ForeignKeyInfo foreignKey)
        {
            manager?.GetNamingManager()?.ForeignKeyNamingManager?.Correct(foreignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="uniqueKey"></param>
        public static void CorrectName(this IMigrateManager manager, UniqueKeyInfo uniqueKey)
        {
            manager?.GetNamingManager()?.UniqueKeyNamingManager?.Correct(uniqueKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static INamingManager GetNamingManager(this IMigrateManager manager)
        {
            return manager.ServicesContainer.GetService<INamingManager>();
        }
    }
}
