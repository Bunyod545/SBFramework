using MySql.Data.MySqlClient;
using SB.Common.Extensions;
using SB.Migrator.Models.MigrationHistorys;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlMigrationHistory : MigrationHistory
    {
        /// <summary>
        /// 
        /// </summary>
        public MySqlMigrationHistory(MySqlDataReader reader)
        {
            Name = reader[nameof(MigrationsHistoryTable.Name)].ToSafeString();
            Version = reader[nameof(MigrationsHistoryTable.Version)].ToSafeString();
            Version2 = reader[nameof(MigrationsHistoryTable.Version2)].ToSafeString();
        }
    }
}
