using System.Collections.Generic;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlTableManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<SqlTable> SqlTables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SqlTable> GetTables()
        {
            return SqlTables ?? new List<SqlTable>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitializeTables()
        {
            SqlTables = new List<SqlTable>();
            var command = SqlCommandHelper.GetSqlCommand(Scripts.SelectTables);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlTables.Add(new SqlTable(reader["TABLE_SCHEMA"] as string, reader["TABLE_NAME"] as string));
        }
    }
}
