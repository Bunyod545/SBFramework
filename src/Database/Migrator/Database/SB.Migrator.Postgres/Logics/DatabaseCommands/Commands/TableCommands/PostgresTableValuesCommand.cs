using System.Collections.Generic;
using System.Text;
using Npgsql;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Migrator.Extensions;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresTableValuesCommand : PostgresTableCommand, ITableValuesCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.TableValue;

        /// <summary>
        /// 
        /// </summary>
        public List<NpgsqlCommand> Commands { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            Commands = new List<NpgsqlCommand>();
            Table.TableValues.ForEach(BuildValueCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableValueInfo"></param>
        private void BuildValueCommand(TableValueInfo tableValueInfo)
        {
            ScriptBuilder = new StringBuilder();
            BuildUpdateCommand();
            BuildInsertCommand();

            BuildCommand(tableValueInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildUpdateCommand()
        {
            ScriptBuilder.Append("WITH upsert AS (UPDATE ");
            ScriptBuilder.Append($"{GetTableName()} SET ");
            Table.Columns.ForEach(BuildUpdateSet);

            var primaryColumn = Table.GetPrimaryColumnName();
            ScriptBuilder.Append($"WHERE \"{primaryColumn}\" = @{primaryColumn}");
            ScriptBuilder.AppendLine(" RETURNING *)");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildUpdateSet(ColumnInfo column)
        {
            ScriptBuilder.Append($"\"{column.Name}\"");
            ScriptBuilder.Append(" = ");
            ScriptBuilder.Append($"@{column.Name}");

            if (Table.Columns.IsNotLast(column))
                ScriptBuilder.Append(Strings.Comma);

            ScriptBuilder.Append(Strings.WhiteSpace);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildInsertCommand()
        {
            ScriptBuilder.Append("INSERT INTO ");
            ScriptBuilder.Append($"{GetTableName()}");
            ScriptBuilder.Append(Strings.LBracket);

            Table.Columns.ForEach(BuildColumn);
            ScriptBuilder.AppendLine(Strings.RBracket);

            ScriptBuilder.Append("SELECT ");
            Table.Columns.ForEach(BuildValue);

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append("WHERE NOT EXISTS (SELECT 1 FROM upsert);");
        }
        /// <summary>
        /// 
        /// </summary>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.Append($"\"{column.Name}\"");

            if (Table.Columns.IsLast(column))
                return;

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append(Strings.WhiteSpace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildValue(ColumnInfo column)
        {
            ScriptBuilder.Append($"@{column.Name}");

            if (Table.Columns.IsLast(column))
                return;

            ScriptBuilder.Append(Strings.Comma);
            ScriptBuilder.Append(Strings.WhiteSpace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableValueInfo"></param>
        private void BuildCommand(TableValueInfo tableValueInfo)
        {
            var command = new NpgsqlCommand();
            command.CommandText = ScriptBuilder.ToString();

            foreach (var valueItem in tableValueInfo.ValueItems)
                command.Parameters.AddWithValue($"{valueItem.Column.Name}", valueItem.Value);

            Commands.Add(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public override void Execute(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            foreach (var command in Commands)
            {
                command.Connection = connection;
                command.Prepare();
                command.ExecuteNonQuery();
            }

            connection.Close();
            Commands.ForEach(f => f.Dispose());
        }
    }
}
