using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SB.Migrator.MySql.ResxFiles;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlColumnManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<MySqlColumn> MySqlColumns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public MySqlColumnManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeColumns()
        {
            MySqlColumns = new List<MySqlColumn>();
            var commandText = string.Format(Scripts.SelectColumns, DatabaseTablesManager.GetDatabaseName());
            var command = GetMySqlCommand(commandText);

            var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return;

            while (reader.Read())
                MySqlColumns.Add(ReaderToColumn(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private MySqlColumn ReaderToColumn(MySqlDataReader reader)
        {
            return new MySqlColumn
            {
                TableSchema = reader["TABLE_SCHEMA"] as string,
                TableName = reader["TABLE_NAME"] as string,
                Name = reader["COLUMN_NAME"] as string,
                Position = (int)reader["ORDINAL_POSITION"],
                DefaultValue = reader["COLUMN_DEFAULT"],
                IsNullable = reader["IS_NULLABLE"]?.ToString() == "YES",
                DataType = reader["DATA_TYPE"] as string,
                CharacterMaximumLenght = reader["character_maximum_length"] as int?,
                CharacterOctetLenght = reader["character_octet_length"] as int?,
                NumericPrecision = reader["numeric_precision"] as int?,
                NumericScale = reader["numeric_scale"] as int?,
                DateTimePrecision = reader["datetime_precision"] as int?,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlTable"></param>
        /// <returns></returns>
        public List<MySqlColumn> GetSqlColumns(MySqlTable sqlTable)
        {
            if (MySqlColumns == null)
                return new List<MySqlColumn>();

            return MySqlColumns.Where(w =>
                w.TableSchema == sqlTable.Schema &&
                w.TableName == sqlTable.Name).ToList();
        }
    }
}
