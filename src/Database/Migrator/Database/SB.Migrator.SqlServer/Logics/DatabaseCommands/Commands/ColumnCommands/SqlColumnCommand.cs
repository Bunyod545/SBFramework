using System.Text;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlColumnCommand : SqlDatabaseCommand, IColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo Column { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table => Column?.Table;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        public virtual void SetColumn(ColumnInfo column)
        {
            Column = column;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetAlterTable()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append(Table.GetSqlName());
            ScriptBuilder.AppendLine();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetColumnInfo()
        {
            ScriptBuilder.Append($" {Column.GetSqlName()} {Column.Type.GetColumnType()}");
            ScriptBuilder.AppendIf(!Column.IsAllowNull, " NOT");
            ScriptBuilder.Append(" NULL");
        }
    }
}
