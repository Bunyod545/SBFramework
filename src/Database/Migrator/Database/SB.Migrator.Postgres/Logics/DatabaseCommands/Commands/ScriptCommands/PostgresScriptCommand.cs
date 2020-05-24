using System;
using System.Text;
using Npgsql;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresScriptCommand : PostgresDatabaseCommand, IScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] Separator => new[] { "GO\r" };

        /// <summary>
        /// 
        /// </summary>
        public ScriptInfo ScriptInfo { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public NpgsqlTransaction Transaction { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptInfo"></param>
        public void SetScript(ScriptInfo scriptInfo)
        {
            ScriptInfo = scriptInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append(ScriptInfo.ScriptText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override NpgsqlCommand GetSqlCommand()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            Transaction = connection.BeginTransaction();

            var command = new NpgsqlCommand(CommandText, connection);
            command.Transaction = Transaction;
            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            try
            {
                InternalExecute();
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                Transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InternalExecute()
        {
            var command = GetSqlCommand();
            var commandTexts = CommandText.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (var commandText in commandTexts)
            {
                if (string.IsNullOrEmpty(commandText))
                    continue;

                command.CommandText = commandText;
                command.ExecuteNonQuery();
            }

            Transaction.Commit();
            command.Connection?.Close();
            command.Dispose();
        }
    }
}
