using System.Text;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresColumnCommand : PostgresDatabaseCommand, IColumnCommand
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
            ScriptBuilder.Append(Table.GetPgSqlName());
            ScriptBuilder.AppendLine();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetColumnInfo()
        {
            ScriptBuilder.Append($" {Column.GetPgSqlName()} {Column.Type.GetColumnType()}");
            SetColumnNullableInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetColumnNullableInfo()
        {
            if (!Column.IsAllowNull)
                ScriptBuilder.Append(" NOT");

            ScriptBuilder.Append(" NULL;");
        }
    }
}
