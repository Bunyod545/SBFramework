using System.Collections.Generic;
using SB.Migrator.Logics.Database.Interfaces;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlTableManager : SqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public List<SqlTable> SqlTables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        public SqlTableManager(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SqlTable> GetTables()
        {
            return SqlTables ?? new List<SqlTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeTables()
        {
            SqlTables = new List<SqlTable>();
            var command = GetSqlCommand(Scripts.SelectTables);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlTables.Add(new SqlTable(reader["TABLE_SCHEMA"] as string, reader["TABLE_NAME"] as string));

            const string name = MigrationsHistoryRepositoryHelper.HistoryTable;
            const string schema = MigrationsHistoryRepositoryHelper.HistoryTableSchema;
            SqlTables.RemoveAll(r => r.Name == name && r.Schema == schema);
        }

    }
}
