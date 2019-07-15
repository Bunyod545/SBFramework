using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SB.Migrator.MySql.ResxFiles;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlPrimaryKeyManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<MySqlPrimaryKey> MySqlPrimaryKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public MySqlPrimaryKeyManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializePrimaryKeys()
        {
            MySqlPrimaryKeys = new List<MySqlPrimaryKey>();

            var commandText = string.Format(Scripts.SelectPrimaryKeys, DatabaseTablesManager.GetDatabaseName());
            var command = GetMySqlCommand(commandText);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                MySqlPrimaryKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private MySqlPrimaryKey ReaderToPrimaryKey(MySqlDataReader reader)
        {
            return new MySqlPrimaryKey
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                ColumnName = reader["COLUMN_NAME"] as string,
                ConstraintName = reader["CONSTRAINT_NAME"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public MySqlPrimaryKey GetPrimaryKey(MySqlTable table)
        {
            return MySqlPrimaryKeys?.FirstOrDefault(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name);
        }
    }
}
