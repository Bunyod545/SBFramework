using System.Collections.Generic;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

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
        public List<ColumnInfo> Columns => Table?.Columns;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public virtual void SetTable(TableInfo info)
        {
            Table = info;
        }
    }
}
