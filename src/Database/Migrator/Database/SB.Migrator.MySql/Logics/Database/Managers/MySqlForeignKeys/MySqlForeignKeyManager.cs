using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SB.Migrator.Models;
using SB.Migrator.MySql.ResxFiles;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlForeignKeyManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<MySqlForeignKey> MySqlForeignKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public MySqlForeignKeyManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializeForeignKeys()
        {
            MySqlForeignKeys = new List<MySqlForeignKey>();

            var commandText = string.Format(Scripts.SelectForeignKeys, DatabaseTablesManager.GetDatabaseName());
            var command = GetMySqlCommand(commandText);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                MySqlForeignKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private MySqlForeignKey ReaderToPrimaryKey(MySqlDataReader reader)
        {
            return new MySqlForeignKey
            {
                ConstraintName = reader["CONSTRAINT_NAME"] as string,
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                ColumnName = reader["COLUMN_NAME"] as string,
                ReferencedTableSchema = reader["REFERENCED_TABLE_SCHEMA"] as string,
                ReferencedTableName = reader["REFERENCED_TABLE_NAME"] as string,
                ReferencedColumnName = reader["REFERENCED_COLUMN_NAME"] as string,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<MySqlForeignKey> GetForeignKeys(TableInfo table)
        {
            if (MySqlForeignKeys == null)
                return new List<MySqlForeignKey>();

            return MySqlForeignKeys.Where(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name).ToList();
        }
    }
}
