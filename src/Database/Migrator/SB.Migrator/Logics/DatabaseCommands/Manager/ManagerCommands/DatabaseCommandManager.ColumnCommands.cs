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
        protected virtual void CreateColumn(ColumnInfo column)
        {
            ColumnCommand<ICreateColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void AlterColumn(ColumnInfo column, ColumnInfo databaseColumn)
        {
            var alterColumnCommand = ColumnCommand<IAlterColumnCommand>(column);
            alterColumnCommand?.SetDatabaseColumn(databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        protected virtual void RenameColumn(ColumnInfo column)
        {
            ColumnCommand<IRenameColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        protected virtual void DropColumn(ColumnInfo column)
        {
            ColumnCommand<IDropColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        protected virtual T ColumnCommand<T>(ColumnInfo column) where T : class, IColumnCommand
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
