using System.Text;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Migrator.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlCreateTableCommand : MySqlTableCommand, ICreateTableCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateTable;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("CREATE TABLE ");
            ScriptBuilder.Append(Table.GetMySqlName());
            ScriptBuilder.Append(Strings.LBracket);
            Columns.ForEach(BuildColumn);

            var primaryColumn = Table.PrimaryKey?.PrimaryColumn;
            if (primaryColumn != null)
            {
                ScriptBuilder.AppendLine(Strings.Comma);
                ScriptBuilder.AppendLine($"PRIMARY KEY ({primaryColumn.GetMySqlName()})");
            }

            ScriptBuilder.Append(Strings.RBracket);
            ScriptBuilder.AppendLine(" ENGINE=INNODB");
            ScriptBuilder.Append($"COMMENT = '{Table.Description}';");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append($"{column.GetMySqlName()} ");
            ScriptBuilder.Append(column.Type.GetColumnType());

            if (column.Identity != null)
                ScriptBuilder.Append(" AUTO_INCREMENT");

            BuildNullableInfo(column);
            ScriptBuilder.Append($" COMMENT '{column.Decription}'");
            ScriptBuilder.AppendIf(Columns.IsNotLast(column), Strings.Comma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildNullableInfo(ColumnInfo column)
        {
            if (!column.IsAllowNull)
                ScriptBuilder.Append(" NOT");

            ScriptBuilder.Append(" NULL");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            MigrationCommandEvents.TableCreatedInvoke(Table);
        }
    }
}
