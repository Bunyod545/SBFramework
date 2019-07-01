using SB.Migrator.Models.Column;

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
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void CreateColumnDefaultValue(ColumnInfo column, ColumnInfo databaseColumn)
        {
            ColumnDefaultValueCommand<ICreateColumnDefaultValueCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void DropColumnDefaultValue(ColumnInfo column)
        {
            ColumnDefaultValueCommand<IDropColumnDefaultValueCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        protected virtual T ColumnDefaultValueCommand<T>(ColumnInfo column) where T : class, IColumnDefaultValueCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return null;

            service.SetColumn(column);
            Commands.Add(service);
            return service;
        }
    }
}
