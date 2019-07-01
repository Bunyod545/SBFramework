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
            TableCommand<ITableValuesCommand>(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        protected virtual T TableCommand<T>(TableInfo table) where T : class, ITableCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return null;

            service.SetTable(table);
            Commands.Add(service);
            return service;
        }
    }
}
