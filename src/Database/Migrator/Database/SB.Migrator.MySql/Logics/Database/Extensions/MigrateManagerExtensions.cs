using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrateManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MigrateManager UseMySqlServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.Register<IDatabaseTablesManager, MySqlDatabaseTablesManager>();
            migrateManager.ServicesContainer.Register<IDatabaseCreator, MySqlDatabaseCreator>();
            migrateManager.ServicesContainer.Register<IMigrationsHistoryRepository, MySqlMigrationsHistoryRepository>();
            migrateManager.ServicesContainer.Register<IColumnTypeMappingSource, MySqlColumnTypeMappingSource>();

            RegisterDatabaseCommands(migrateManager);
            return migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RegisterDatabaseCommands(MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.RegisterTransient<ICreateTableCommand, MySqlCreateTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameTableCommand, MySqlRenameTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropTableCommand, MySqlDropTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<ITableValuesCommand, MySqlTableValuesCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnCommand, MySqlCreateColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IAlterColumnCommand, MySqlAlterColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameColumnCommand, MySqlRenameColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnCommand, MySqlDropColumnCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnDefaultValueCommand, MySqlCreateColumnDefaultValueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnDefaultValueCommand, MySqlDropColumnDefaultValueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateUniqueKeyCommand, MySqlCreateUniqueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropUniqueKeyCommand, MySqlDropUniqueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreatePrimaryKeyCommand, MySqlCreatePrimaryKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropPrimaryKeyCommand, MySqlDropPrimaryKeyCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateForeignKeyCommand, MySqlCreateForeignKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropForeignKeyCommand, MySqlDropForeignKeyCommand>();

            migrateManager.ServicesContainer.Register<IBeforeActualizationScriptCommand, MySqlBeforeActualizationScriptCommand>();
            migrateManager.ServicesContainer.Register<IAfterActualizationScriptCommand, MySqlAfterActualizationScriptCommand>();
        }
    }
}
