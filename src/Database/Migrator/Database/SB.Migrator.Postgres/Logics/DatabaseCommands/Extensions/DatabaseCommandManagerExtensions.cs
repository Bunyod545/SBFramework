using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public static class DatabaseCommandManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static IDatabaseCommandManager UsePostgresCommands(this IDatabaseCommandManager manager)
        {
            manager.CommandServices.ResetServices();
            manager.CommandServices.Add<ICreateTableCommand, PostgresCreateTableCommand>();
            manager.CommandServices.Add<IRenameTableCommand, PostgresRenameTableCommand>();
            manager.CommandServices.Add<ITableValuesCommand, PostgresTableValuesCommand>();

            manager.CommandServices.Add<ICreateColumnCommand, PostgresCreateColumnCommand>();
            manager.CommandServices.Add<IAlterColumnCommand, PostgresAlterColumnCommand>();
            manager.CommandServices.Add<IRenameColumnCommand, PostgresRenameColumnCommand>();

            manager.CommandServices.Add<ICreateColumnDefaultValueCommand, PostgresCreateColumnDefaultValueCommand>();
            manager.CommandServices.Add<ICreatePrimaryKeyCommand, PostgresCreatePrimaryKeyCommand>();
            manager.CommandServices.Add<ICreateForeignKeyCommand, PostgresCreateForeignKeyCommand>();

            manager.CommandServices.Add<IBeforeActualizationScriptCommand, PostgresBeforeActualizationScriptCommand>();
            manager.CommandServices.Add<IAfterActualizationScriptCommand, PostgresAfterActualizationScriptCommand>();

            return manager;
        }
    }
}
