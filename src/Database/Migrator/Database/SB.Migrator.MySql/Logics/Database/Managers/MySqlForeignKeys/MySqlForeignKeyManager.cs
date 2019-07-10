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
            var command = GetMySqlCommand(Scripts.SelectForeignKeys);
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
                ConstraintName = reader["constraint_name"] as string,
                TableSchema = reader["table_schema"] as string,
                TableName = reader["table_name"] as string,
                ColumnName = reader["column_name"] as string,
                ReferencedTableSchema = reader["foreign_table_schema"] as string,
                ReferencedTableName = reader["foreign_table_name"] as string,
                ReferencedColumnName = reader["foreign_column_name"] as string,
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
