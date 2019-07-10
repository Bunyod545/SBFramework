using System.Collections.Generic;
using SB.Migrator.MySql.ResxFiles;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlTableManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MySqlTable> MySqlTables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public MySqlTableManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MySqlTable> GetTables()
        {
            return MySqlTables ?? new List<MySqlTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeTables()
        {
            MySqlTables = new List<MySqlTable>();
            var dbName = DatabaseTablesManager.GetDatabaseName();

            var commandText = string.Format(Scripts.SelectTables, dbName);
            var command = GetMySqlCommand(commandText);

            var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return;

            while (reader.Read())
                MySqlTables.Add(new MySqlTable(reader["TABLE_SCHEMA"] as string, reader["TABLE_NAME"] as string));

            const string name = MigrationsHistoryRepositoryHelper.HistoryTable;
            MySqlTables.RemoveAll(r => r.Name == name && r.Schema == dbName);
        }
    }
}
