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
        protected virtual void CreateColumnDefaultValue(ColumnInfo column)
        {
            ColumnDefaultValueCommand<ICreateColumnDefaultValueCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        protected virtual void DropColumnDefaultValue(ColumnInfo column)
        {
            ColumnDefaultValueCommand<IDropColumnDefaultValueCommand>(column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        protected virtual void ColumnDefaultValueCommand<T>(ColumnInfo column) where T : class, IColumnDefaultValueCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return;

            service.SetColumn(column);
            service.BuildCommandText();
        }
    }
}
