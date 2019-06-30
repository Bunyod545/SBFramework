using System.Text;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Migrator.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresCreateTableCommand : PostgresTableCommand, ICreateTableCommand
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
            ScriptBuilder.AppendFormat("{0}.\"{1}\"", Table.Schema, Table.Name);
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
            ScriptBuilder.AppendFormat("\"{0}\" ", column.Name);
            ScriptBuilder.Append(column.Type.GetColumnType());

            BuildIdentity(column);
            BuildNullableInfo(column);

            if (Table.Columns.IsNotLast(column))
                ScriptBuilder.Append(Strings.Comma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildIdentity(ColumnInfo column)
        {
            if (column.Identity != null)
                ScriptBuilder.Append(" PRIMARY KEY");
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
