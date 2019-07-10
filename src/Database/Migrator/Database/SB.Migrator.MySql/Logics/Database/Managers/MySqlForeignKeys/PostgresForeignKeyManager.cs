using System.Collections.Generic;
using System.Linq;
using Npgsql;
using SB.Migrator.Models;
using SB.Migrator.Postgres.ResxFiles;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresForeignKeyManager : MySqlBaseMappingManager
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<PostgresForeignKey> PostgresForeignKeys { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseTablesManager"></param>
        public PostgresForeignKeyManager(MySqlDatabaseTablesManager databaseTablesManager) : base(databaseTablesManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void InitializeForeignKeys()
        {
            PostgresForeignKeys = new List<PostgresForeignKey>();
            var command = GetPostgresCommand(Scripts.SelectForeignKeys);
            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return;

            while (reader.Read())
                PostgresForeignKeys.Add(ReaderToPrimaryKey(reader));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private PostgresForeignKey ReaderToPrimaryKey(NpgsqlDataReader reader)
        {
            return new PostgresForeignKey
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
        public List<PostgresForeignKey> GetForeignKeys(TableInfo table)
        {
            if (PostgresForeignKeys == null)
                return new List<PostgresForeignKey>();

            return PostgresForeignKeys.Where(f =>
                f.TableSchema == table.Schema &&
                f.TableName == table.Name).ToList();
        }
    }
}
