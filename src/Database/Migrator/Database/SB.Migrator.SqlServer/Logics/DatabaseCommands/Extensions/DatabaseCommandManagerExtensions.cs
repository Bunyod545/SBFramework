using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
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
        public static IDatabaseCommandManager UseSqlCommands(this IDatabaseCommandManager manager)
        {
            manager.CommandServices.ResetServices();
            manager.CommandServices.Add<ICreateTableCommand, SqlCreateTableCommand>();
            manager.CommandServices.Add<IDropTableCommand, SqlDropTableCommand>();
            manager.CommandServices.Add<IRenameTableCommand, SqlRenameTableCommand>();

            manager.CommandServices.Add<ICreateColumnCommand, SqlCreateColumnCommand>();
            manager.CommandServices.Add<IAlterColumnCommand, SqlAlterColumnCommand>();
            manager.CommandServices.Add<IDropColumnCommand, SqlDropColumnCommand>();
            manager.CommandServices.Add<IRenameColumnCommand, SqlRenameColumnCommand>();

            manager.CommandServices.Add<ICreateColumnDefaultValueCommand, SqlCreateColumnDefaultValueCommand>();
            manager.CommandServices.Add<IDropColumnDefaultValueCommand, SqlDropColumnDefaultValueCommand>();

            manager.CommandServices.Add<ICreatePrimaryKeyCommand, SqlCreatePrimaryKeyCommand>();
            manager.CommandServices.Add<IDropPrimaryKeyCommand, SqlDropPrimaryKeyCommand>();

            manager.CommandServices.Add<ICreateForeignKeyCommand, SqlCreateForeignKeyCommand>();
            manager.CommandServices.Add<IDropForeignKeyCommand, SqlDropForeignKeyCommand>();

            return manager;
        }
    }
}
