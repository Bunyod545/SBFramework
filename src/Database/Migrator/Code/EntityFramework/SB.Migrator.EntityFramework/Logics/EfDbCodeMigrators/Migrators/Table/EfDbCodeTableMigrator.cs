using System.Collections.Generic;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Logics.ServiceContainers;
using SB.Migrator.Models;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EfDbCodeTableMigrator : IEfDbCodeTableMigrator
    {
        /// <summary>
        /// 
        /// </summary>
        internal readonly IMigrateServicesContainer _servicesContainer;

        /// <summary>
        /// 
        /// </summary>
        private readonly List<IDatabaseCommand> _commands;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicesContainer"></param>
        public EfDbCodeTableMigrator(IMigrateServicesContainer servicesContainer)
        {
            _servicesContainer = servicesContainer;
            _commands = new List<IDatabaseCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        public EfDbCodeTableBuilder CreateTable(string tableName, string schemaName = null)
        {
            var tableInfo = new TableInfo();
            tableInfo.Name = tableName;
            tableInfo.Schema = schemaName;

            var createTableCommand = _servicesContainer.GetService<ICreateTableCommand>();
            createTableCommand.SetTable(tableInfo);
            _commands.Add(createTableCommand);

            return new EfDbCodeTableBuilder(_servicesContainer, tableInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="schema"></param>
        public void DropTable(string table, string schema = null)
        {
            var tableInfo = new TableInfo();
            tableInfo.Name = table;
            tableInfo.Schema = schema;

            var dropTableCommand = _servicesContainer.GetService<IDropTableCommand>();
            dropTableCommand.SetTable(tableInfo);
            _commands.Add(dropTableCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldTableName"></param>
        /// <param name="newTableName"></param>
        /// <param name="schema"></param>
        public void RenameTable(string oldTableName, string newTableName, string schema = null)
        {
            var tableInfo = new TableInfo();
            tableInfo.Name = oldTableName;
            tableInfo.Schema = schema;
            tableInfo.NewName = newTableName;

            var renameTableCommand = _servicesContainer.GetService<IRenameTableCommand>();
            renameTableCommand.SetTable(tableInfo);
            _commands.Add(renameTableCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IDatabaseCommand> GetCommands()
        {
            return _commands;
        }
    }
}
