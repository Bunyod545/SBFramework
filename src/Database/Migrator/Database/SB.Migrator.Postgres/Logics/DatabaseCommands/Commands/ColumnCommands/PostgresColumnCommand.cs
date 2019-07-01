using System.Text;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;
using SB.Migrator.Postgres;

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
            ScriptBuilder.Append($"{Column.Table.Schema}.\"{Column.Table.Name}\"");
            ScriptBuilder.AppendLine();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetColumnInfo()
        {
            ScriptBuilder.Append($" \"{Column.Name}\" {Column.Type.GetColumnType()}");

            if (!Column.IsAllowNull)
                ScriptBuilder.Append(" NOT");

            ScriptBuilder.Append(" NULL");
        }
    }
}
