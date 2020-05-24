using Npgsql;
using SB.Common.Extensions;
using SB.Migrator.Models.MigrationHistories;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresMigrationHistory : MigrationHistory
    {
        /// <summary>
        /// 
        /// </summary>
        public PostgresMigrationHistory(NpgsqlDataReader reader)
        {
            Name = reader[nameof(MigrationsHistoryTable.Name)].ToSafeString();
            Version = reader[nameof(MigrationsHistoryTable.Version)].ToSafeString();
            Version2 = reader[nameof(MigrationsHistoryTable.Version2)].ToSafeString();
        }
    }
}
