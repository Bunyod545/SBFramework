using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SB.Common.Extensions;
using SB.Migrator.Logics.Database.Interfaces;
using SB.Migrator.SqlServer.ResxFiles;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlUniqueKeyManager : SqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<SqlUniqueKey> SqlUniqueKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConnection"></param>
        public SqlUniqueKeyManager(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializeUniqueKeys()
        {
            SqlUniqueKeys = new List<SqlUniqueKey>();
            var command = GetSqlCommand(Scripts.SelectUniqueKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                SqlUniqueKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private SqlUniqueKey ReaderToPrimaryKey(SqlDataReader reader)
        {
            return new SqlUniqueKey
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                ColumnName = reader["Column_Name"] as string,
                ConstraintName = reader["Constraint_Name"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<SqlUniqueKeyInfo> GetUniqueKeys(SqlTable table)
        {
            var keys = SqlUniqueKeys.ToList(w => w.TableName == table.Name && w.TableSchema == table.Schema);
            return keys.GroupBy(g => g.ConstraintName).Select(s => new SqlUniqueKeyInfo(s)).ToList();
        }
    }
}
