using SB.Migrator.Models;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        protected virtual void CreateTable(TableInfo table)
        {
            TableCommand<ICreateTableCommand>(table);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        protected virtual void DropTable(TableInfo table)
        {
            TableCommand<IDropTableCommand>(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        protected virtual void SetTableValues(TableInfo table)
        {
            TableCommand<ISetTableValuesCommand>(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        protected virtual void TableCommand<T>(TableInfo table) where T : class, ITableCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return;

            service.SetTable(table);
            service.BuildCommandText();
            Commands.Add(service);
        }
    }
}
