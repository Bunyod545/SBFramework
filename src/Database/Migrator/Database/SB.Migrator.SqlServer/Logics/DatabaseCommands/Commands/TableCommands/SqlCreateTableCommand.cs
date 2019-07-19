using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreateTableCommand : SqlTableCommand, ICreateTableCommand
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
            ScriptBuilder.AppendFormat(Table.GetSqlName());
            ScriptBuilder.Append(Strings.LBracket);

            Table.Columns.ForEach(BuildColumn);
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(Strings.RBracket);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append($"{column.GetSqlName()} ");
            ScriptBuilder.Append(column.Type.GetColumnType());

            BuildIdentity(column);
            BuildNullableInfo(column);

            ScriptBuilder.Append(Strings.Comma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildIdentity(ColumnInfo column)
        {
            if (column.Identity != null)
                ScriptBuilder.AppendFormat(" IDENTITY({0},{1})", column.Identity.Increment, column.Identity.Seed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildNullableInfo(ColumnInfo column)
        {
            ScriptBuilder.AppendIf(!column.IsAllowNull, " NOT");
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
