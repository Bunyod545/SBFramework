using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SB.Common.Extensions;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistorys;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrationsHistoryRepositoryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const string HistoryTable = "MigrationsHistory";

        /// <summary>
        /// 
        /// </summary>
        public const string HistoryTableSchema = "dbo";

        /// <summary>
        /// 
        /// </summary>
        protected SqlMigrationsHistoryRepository Repository { get; }

        /// <summary>
        /// 
        /// </summary>
        protected string ConnectionString => Repository?.MigrateManager?.ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public MigrationsHistoryRepositoryHelper(SqlMigrationsHistoryRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsHistoryTableExists()
        {
            var command = GetCommand($"SELECT OBJECT_ID('{HistoryTable}', 'U')");
            var result = !(command.ExecuteScalar() is DBNull);

            DisposeCommand(command);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateHistoryTable()
        {
            var table = new TableInfo();
            table.Name = HistoryTable;
            table.Schema = HistoryTableSchema;

            var idColumn = MigrationsHistoryTableHelper.GetIdColumn();
            idColumn.Table = table;
            table.Columns.Add(idColumn);

            table.PrimaryKey = new PrimaryKeyInfo();
            table.PrimaryKey.PrimaryColumn = idColumn;
            table.PrimaryKey.Table = table;

            var nameColumn = MigrationsHistoryTableHelper.GetNameColumn();
            nameColumn.Table = table;
            table.Columns.Add(nameColumn);

            var versionColumn = MigrationsHistoryTableHelper.GetVersionColumn();
            versionColumn.Table = table;
            table.Columns.Add(versionColumn);

            var version2Column = MigrationsHistoryTableHelper.GetVersion2Column();
            version2Column.Table = table;
            table.Columns.Add(version2Column);

            var createTableCommand = new SqlCreateTableCommand();
            createTableCommand.SetTable(table);
            createTableCommand.BuildCommandText();
            createTableCommand.Execute(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MigrationHistory> GetMigrationHistories()
        {
            var command = GetCommand(Scripts.SelectMigrationsHistory);
            var reader = command.ExecuteReader();

            while (reader.Read())
                yield return new SqlMigrationHistory(reader);

            DisposeCommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void SetVersion(string name, string version)
        {
            if (!IsRowExists(name))
            {
                InsertVersion(name, version);
                return;
            }

            UpdateVersion(name, version);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void InsertVersion(string name, string version)
        {
            var commandText = string.Format(Scripts.InsertHistoryVersion, name, version);
            var command = GetCommand(commandText);

            command.ExecuteNonQuery();
            DisposeCommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void UpdateVersion(string name, string version)
        {
            var commandText = string.Format(Scripts.UpdateHistoryVersion, name, version);
            var command = GetCommand(commandText);

            command.ExecuteNonQuery();
            DisposeCommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void SetVersion2(string name, string version)
        {
            var isRowExists = IsRowExists(name);
            if (!isRowExists)
                InsertVersion2(name, version);

            if (isRowExists)
                UpdateVersion2(name, version);

            var history = GetMigrationHistory(name);
            if (history == null)
                return;

            if (history.Version.IsNullOrEmpty())
            {
                SetVersion(name, version);
                return;
            }

            var mainVersion = Version.Parse(history.Version);
            var additionalVersion = Version.Parse(history.Version2);
            if (mainVersion < additionalVersion)
                SetVersion(name, additionalVersion.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MigrationHistory GetMigrationHistory(string name)
        {
            var commandText = string.Format(Scripts.SelectHistory, name);
            var command = GetCommand(commandText);
            var reader = command.ExecuteReader();

            var result = !reader.Read() ? null : new SqlMigrationHistory(reader);
            DisposeCommand(command);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version2"></param>
        public void InsertVersion2(string name, string version2)
        {
            var commandText = string.Format(Scripts.InsertHistoryVersion2, name, version2);
            var command = GetCommand(commandText);

            command.ExecuteNonQuery();
            DisposeCommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version2"></param>
        public void UpdateVersion2(string name, string version2)
        {
            var commandText = string.Format(Scripts.UpdateHistoryVersion2, name, version2);
            var command = GetCommand(commandText);

            command.ExecuteNonQuery();
            DisposeCommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsRowExists(string name)
        {
            var commandText = string.Format(Scripts.SelectHistory, name);
            var command = GetCommand(commandText);

            var result = command.ExecuteScalar() != null;
            DisposeCommand(command);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void DisposeCommand(SqlCommand command)
        {
            command.Connection.Close();
            command.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SqlCommand GetCommand(string commandText)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return new SqlCommand(commandText, connection);
        }
    }
}
