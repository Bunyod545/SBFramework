using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres.Logics.Database.Extensions
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
        public static MigrateManager UsePostgresServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.Register<IDatabaseTablesManager, PostgresDatabaseTablesManager>();
            migrateManager.ServicesContainer.Register<IDatabaseCreator, PostgresDatabaseCreator>();
            migrateManager.ServicesContainer.Register<IMigrationsHistoryRepository, PostgresMigrationsHistoryRepository>();
            migrateManager.ServicesContainer.Register<IColumnTypeMappingSource, PostgresColumnTypeMappingSource>();

            migrateManager.ServicesContainer.Register<PostgresTableManager>();
            migrateManager.ServicesContainer.Register<PostgresColumnManager>();
            migrateManager.ServicesContainer.Register<PostgresPrimaryKeyManager>();
            migrateManager.ServicesContainer.Register<PostgresUniqueKeyManager>();
            migrateManager.ServicesContainer.Register<PostgresForeignKeyManager>();

            RegisterDatabaseCommands(migrateManager);
            return migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RegisterDatabaseCommands(MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.RegisterTransient<ICreateTableCommand, PostgresCreateTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameTableCommand, PostgresRenameTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropTableCommand, PostgresDropTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<ITableValuesCommand, PostgresTableValuesCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnCommand, PostgresCreateColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IAlterColumnCommand, PostgresAlterColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameColumnCommand, PostgresRenameColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnCommand, PostgresDropColumnCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnDefaultValueCommand, PostgresCreateColumnDefaultValueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnDefaultValueCommand, PostgresDropColumnDefaultValueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateUniqueKeyCommand, PostgresCreateUniqueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropUniqueKeyCommand, PostgresDropUniqueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreatePrimaryKeyCommand, PostgresCreatePrimaryKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropPrimaryKeyCommand, PostgresDropPrimaryKeyCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateForeignKeyCommand, PostgresCreateForeignKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropForeignKeyCommand, PostgresDropForeignKeyCommand>();

            migrateManager.ServicesContainer.Register<IBeforeActualizationScriptCommand, PostgresBeforeActualizationScriptCommand>();
            migrateManager.ServicesContainer.Register<IAfterActualizationScriptCommand, PostgresAfterActualizationScriptCommand>();
        }
    }
}
