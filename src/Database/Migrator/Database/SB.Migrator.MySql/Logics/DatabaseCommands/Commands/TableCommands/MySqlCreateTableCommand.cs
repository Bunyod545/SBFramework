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
            ScriptBuilder.AppendFormat("`{0}`.`{1}`", Table.Schema, Table.Name);
            ScriptBuilder.Append(Strings.LBracket);
            Table.Columns.ForEach(BuildColumn);

            var primaryColumn = Table.PrimaryKey?.PrimaryColumn;
            if (primaryColumn != null)
            {
                ScriptBuilder.AppendLine(Strings.Comma);
                ScriptBuilder.AppendLine($"PRIMARY KEY (`{primaryColumn.Name}`)");
            }

            ScriptBuilder.Append(Strings.RBracket);
            ScriptBuilder.Append(" ENGINE=INNODB;");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendFormat("`{0}` ", column.Name);
            ScriptBuilder.Append(column.Type.GetColumnType());

            if (column.Identity != null)
                ScriptBuilder.Append(" AUTO_INCREMENT");

            BuildNullableInfo(column);

            if (Table.Columns.IsNotLast(column))
                ScriptBuilder.Append(Strings.Comma);
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
        /// <param name="connectionString"></param>
        public override void Execute(string connectionString)
        {
            base.Execute(connectionString);
            MigrationCommandEvents.TableCreatedInvoke(Table);
        }
    }
}
