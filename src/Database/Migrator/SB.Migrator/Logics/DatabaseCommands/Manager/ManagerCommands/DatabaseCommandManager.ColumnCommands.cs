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
        /// <param name="column"></param>
        protected virtual void CreateColumn(ColumnInfo column)
        {
            ColumnCommand<ICreateColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        protected virtual void AlterColumn(ColumnInfo column)
        {
            ColumnCommand<IAlterColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        protected virtual void RenameColumn(ColumnInfo column)
        {
            ColumnCommand<IRenameColumnCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
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
        protected virtual void ColumnCommand<T>(ColumnInfo column) where T : class, IColumnCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return;

            service.SetColumn(column);
            service.BuildCommandText();
            Commands.Add(service);
        }
    }
}
