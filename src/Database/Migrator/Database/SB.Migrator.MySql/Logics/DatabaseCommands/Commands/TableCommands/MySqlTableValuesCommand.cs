using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Migrator.Extensions;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlTableValuesCommand : MySqlTableCommand, ITableValuesCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.TableValue;

        /// <summary>
        /// 
        /// </summary>
        public List<MySqlCommand> Commands { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            Commands = new List<MySqlCommand>();
            Table.TableValues.ForEach(BuildValueCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableValueInfo"></param>
        private void BuildValueCommand(TableValueInfo tableValueInfo)
        {
            ScriptBuilder = new StringBuilder();
            BuildInsertCommand();
            BuildCommand(tableValueInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildInsertCommand()
        {
            ScriptBuilder.Append("INSERT INTO ");
            ScriptBuilder.Append($"{Table.GetMySqlName()}");

            ScriptBuilder.Append(Strings.LBracket);
            Table.Columns.ForEach(BuildColumn);
            ScriptBuilder.AppendLine(Strings.RBracket);

            ScriptBuilder.Append("VALUES");
            ScriptBuilder.Append(Strings.LBracket);
            Table.Columns.ForEach(BuildValue);
            ScriptBuilder.AppendLine(Strings.RBracket);

            ScriptBuilder.AppendLine("ON DUPLICATE KEY UPDATE");
            Table.Columns.ForEach(BuildColumnAndValue);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.Append($"{column.GetMySqlName()}");

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
        /// <param name="column"></param>
        private void BuildColumnAndValue(ColumnInfo column)
        {
            ScriptBuilder.Append($"{column.Name}=");
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
            var command = new MySqlCommand();
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
            var connection = new MySqlConnection(connectionString);
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
