using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
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
        public static IDatabaseCommandManager UseMySqlCommands(this IDatabaseCommandManager manager)
        {
            manager.CommandServices.ResetServices();
            manager.CommandServices.Add<ICreateTableCommand, MySqlCreateTableCommand>();
            manager.CommandServices.Add<IRenameTableCommand, MySqlRenameTableCommand>();
            manager.CommandServices.Add<ITableValuesCommand, MySqlTableValuesCommand>();

            manager.CommandServices.Add<ICreateColumnCommand, MySqlCreateColumnCommand>();
            manager.CommandServices.Add<IAlterColumnCommand, MySqlAlterColumnCommand>();
            manager.CommandServices.Add<IRenameColumnCommand, MySqlRenameColumnCommand>();

            manager.CommandServices.Add<ICreateColumnDefaultValueCommand, MySqlCreateColumnDefaultValueCommand>();
            manager.CommandServices.Add<ICreatePrimaryKeyCommand, MySqlCreatePrimaryKeyCommand>();
            manager.CommandServices.Add<ICreateForeignKeyCommand, MySqlCreateForeignKeyCommand>();
            manager.CommandServices.Add<ICreateUniqueKeyCommand, MySqlCreateUniqueCommand>();

            manager.CommandServices.Add<IBeforeActualizationScriptCommand, MySqlBeforeActualizationScriptCommand>();
            manager.CommandServices.Add<IAfterActualizationScriptCommand, MySqlAfterActualizationScriptCommand>();

            return manager;
        }
    }
}
