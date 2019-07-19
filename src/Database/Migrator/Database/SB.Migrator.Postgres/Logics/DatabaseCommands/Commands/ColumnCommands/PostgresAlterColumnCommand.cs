using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresAlterColumnCommand : PostgresColumnCommand, IAlterColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.AlterColumn;

        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo DatabaseColumn { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        public void SetDatabaseColumn(ColumnInfo column)
        {
            DatabaseColumn = column;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            SetAlterTable();
            BuildColumnType();
            BuildColumnAllowNull();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BuildColumnType()
        {
            var type = Column.Type.GetColumnType();
            if (type == DatabaseColumn.Type.GetColumnType())
                return;

            ScriptBuilder.AppendLine($"ALTER COLUMN {Column.GetPgSqlName()} TYPE {type};");
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BuildColumnAllowNull()
        {
            if (Column.IsAllowNull == DatabaseColumn.IsAllowNull)
                return;

            ScriptBuilder.AppendLine($"ALTER COLUMN {Column.GetPgSqlName()}");
            if (Column.IsAllowNull)
                ScriptBuilder.Append(" DROP NOT NULL");

            if (!Column.IsAllowNull)
                ScriptBuilder.Append(" SET NOT NULL");

            ScriptBuilder.Append(Strings.Semicolon);
        }
    }
}
