using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlTableCommand : MySqlDatabaseCommand, ITableCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public virtual void SetTable(TableInfo info)
        {
            Table = info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetTableName()
        {
            return $"{Table.Schema}.`{Table.Name}`";
        }
    }
}
