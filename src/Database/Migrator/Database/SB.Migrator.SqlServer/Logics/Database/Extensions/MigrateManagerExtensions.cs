using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.ColumnTypeMappingSource;

namespace SB.Migrator.SqlServer
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
        public static MigrateManager UseSqlServerDatabase(this MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.Register<IDatabaseTablesManager, SqlDatabaseTablesManager>();
            migrateManager.ServicesContainer.Register<IDatabaseCreator, SqlDatabaseCreator>();
            migrateManager.ServicesContainer.Register<IMigrationsHistoryRepository, SqlMigrationsHistoryRepository>();
            migrateManager.ServicesContainer.Register<IColumnTypeMappingSource, SqlColumnTypeMappingSource>();

            migrateManager.ServicesContainer.Register<SqlTableManager>();
            migrateManager.ServicesContainer.Register<SqlColumnManager>();
            migrateManager.ServicesContainer.Register<SqlUniqueKeyManager>();
            migrateManager.ServicesContainer.Register<SqlPrimaryKeyManager>();
            migrateManager.ServicesContainer.Register<SqlForeignKeyManager>();

            RegisterDatabaseCommands(migrateManager);
            return migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RegisterDatabaseCommands(MigrateManager migrateManager)
        {
            migrateManager.ServicesContainer.RegisterTransient<ICreateTableCommand, SqlCreateTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameTableCommand, SqlRenameTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropTableCommand, SqlDropTableCommand>();
            migrateManager.ServicesContainer.RegisterTransient<ITableValuesCommand, SqlTableValuesCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnCommand, SqlCreateColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IAlterColumnCommand, SqlAlterColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IRenameColumnCommand, SqlRenameColumnCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnCommand, SqlDropColumnCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateColumnDefaultValueCommand, SqlCreateColumnDefaultValueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropColumnDefaultValueCommand, SqlDropColumnDefaultValueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateUniqueKeyCommand, SqlCreateUniqueCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropUniqueKeyCommand, SqlDropUniqueCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreatePrimaryKeyCommand, SqlCreatePrimaryKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropPrimaryKeyCommand, SqlDropPrimaryKeyCommand>();

            migrateManager.ServicesContainer.RegisterTransient<ICreateForeignKeyCommand, SqlCreateForeignKeyCommand>();
            migrateManager.ServicesContainer.RegisterTransient<IDropForeignKeyCommand, SqlDropForeignKeyCommand>();

            migrateManager.ServicesContainer.Register<IBeforeActualizationScriptCommand, SqlBeforeActualizationScriptCommand>();
            migrateManager.ServicesContainer.Register<IAfterActualizationScriptCommand, SqlAfterActualizationScriptCommand>();
        }
    }
}
