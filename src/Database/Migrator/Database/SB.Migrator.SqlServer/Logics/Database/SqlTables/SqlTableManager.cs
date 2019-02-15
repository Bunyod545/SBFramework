using System.Collections.Generic;
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
        /// <param name="databaseTablesManager"></param>
        public SqlTableManager(SqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
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
        }

    }
}
