using System.Collections.Generic;
using System.Text;
using Npgsql;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Migrator.Extensions;
using SB.Migrator.Logics.DatabaseCommands;

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
            BuildIfStatement();
            BuildUpdateCommand();
            BuildInsertCommand();
            BuildCommand(tableValueInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildIfStatement()
        {
            ScriptBuilder.Append("IF EXISTS(SELECT * FROM ");
            ScriptBuilder.AppendFormat(Table.ToString());
            ScriptBuilder.Append(" WHERE ");

            var primaryColumn = Table.GetPrimaryColumnName();
            ScriptBuilder.Append(primaryColumn);
            ScriptBuilder.Append(Strings.Equal);
            ScriptBuilder.Append($"@{primaryColumn}");
            ScriptBuilder.Append(Strings.RBracket);
            ScriptBuilder.AppendLine();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildUpdateCommand()
        {
            ScriptBuilder.Append("UPDATE ");
            ScriptBuilder.AppendFormat(Table.ToString());
            ScriptBuilder.Append(" SET ");

            foreach (var column in Table.GetAdditionalColumns())
            {
                ScriptBuilder.Append(column.Name);
                ScriptBuilder.Append(Strings.Equal);
                ScriptBuilder.Append($"@{column.Name}");

                if (Table.Columns.IsNotLast(column))
                    ScriptBuilder.Append(Strings.Comma);

                ScriptBuilder.Append(Strings.WhiteSpace);
            }

            var primaryColumn = Table.GetPrimaryColumnName();
            ScriptBuilder.Append("WHERE ");
            ScriptBuilder.Append(primaryColumn);
            ScriptBuilder.Append(Strings.Equal);
            ScriptBuilder.Append($"@{primaryColumn}");

            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendLine("ELSE");
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildInsertCommand()
        {
            ScriptBuilder.Append("INSERT INTO ");
            ScriptBuilder.AppendFormat(Table.ToString());
            ScriptBuilder.Append(Strings.LBracket);

            foreach (var column in Table.Columns)
            {
                ScriptBuilder.Append(column.Name);

                if (Table.Columns.IsLast(column))
                    continue;

                ScriptBuilder.Append(Strings.Comma);
                ScriptBuilder.Append(Strings.WhiteSpace);
            }

            ScriptBuilder.AppendLine(Strings.RBracket);
            ScriptBuilder.Append("VALUES(");

            foreach (var column in Table.Columns)
            {
                ScriptBuilder.Append($"@{column.Name}");

                if (Table.Columns.IsLast(column))
                    continue;

                ScriptBuilder.Append(Strings.Comma);
                ScriptBuilder.Append(Strings.WhiteSpace);
            }

            ScriptBuilder.Append(Strings.RBracket);
            ScriptBuilder.Append(Strings.Semicolon);
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
            {
                var param = new NpgsqlParameter();
                param.ParameterName = $"@{valueItem.Column.Name}";
                param.Value = valueItem.Value;

                command.Parameters.Add(param);
            }

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
                command.ExecuteNonQuery();
            }

            connection.Close();
            Commands.ForEach(f => f.Dispose());
        }

    }
}
