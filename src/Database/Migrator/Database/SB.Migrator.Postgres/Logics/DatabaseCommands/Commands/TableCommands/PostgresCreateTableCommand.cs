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
            ScriptBuilder.AppendFormat(Table.GetPgSqlName());
            ScriptBuilder.Append(Strings.LBracket);

            Columns.ForEach(BuildColumn);
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(Strings.RBracket);
            ScriptBuilder.Append(Strings.Semicolon);

            AlterPrimaryKeyIdentitySequence();
            SetComments();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append($"{column.GetPgSqlName()} ");
            ScriptBuilder.Append(column.Type.GetColumnType());

            BuildNullableInfo(column);
            BuildPrimaryKeyAndIdentity(column);
            ScriptBuilder.AppendIf(Columns.IsNotLast(column), Strings.Comma);
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
        /// <param name="column"></param>
        private void BuildPrimaryKeyAndIdentity(ColumnInfo column)
        {
            ScriptBuilder.AppendIf(column.IsPrimary(), " PRIMARY KEY");
            if (column.Identity == null)
                return;

            ScriptBuilder.Append($" DEFAULT nextval('\"{GetSequenceName()}\"')");

            var scriptBuilder = new StringBuilder();
            scriptBuilder.AppendLine($"CREATE SEQUENCE \"{GetSequenceName()}\";");
            scriptBuilder.AppendLine();
            scriptBuilder.Append(ScriptBuilder);

            ScriptBuilder = scriptBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AlterPrimaryKeyIdentitySequence()
        {
            if (Table.PrimaryKey?.PrimaryColumn?.Identity == null)
                return;

            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendLine($"ALTER SEQUENCE \"{GetSequenceName()}\"");
            ScriptBuilder.Append("OWNED BY ");
            ScriptBuilder.Append($"{Table.GetPgSqlName()}.{Table.PrimaryKey.PrimaryColumn.GetPgSqlName()}");
            ScriptBuilder.AppendLine(Strings.Semicolon);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSequenceName()
        {
            return $"{Table.Name}_{Table.PrimaryKey.PrimaryColumn.Name}_seq";
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetComments()
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendLine($"comment on table {Table.GetPgSqlName()} is '{Table.Decription}';");
            Table.Columns.ForEach(SetColumnComment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnInfo"></param>
        private void SetColumnComment(ColumnInfo columnInfo)
        {
            ScriptBuilder.AppendLine($"comment on column {Table.GetPgSqlName()}.{columnInfo.GetPgSqlName()} is '{columnInfo.Decription}';");
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
