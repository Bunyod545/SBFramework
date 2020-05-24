using System.Data.SqlClient;
using SB.Common.Extensions;
using SB.Migrator.Models.MigrationHistories;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlMigrationHistory : MigrationHistory
    {
        /// <summary>
        /// 
        /// </summary>
        public SqlMigrationHistory(SqlDataReader reader)
        {
            Name = reader[nameof(MigrationsHistoryTable.Name)].ToSafeString();
            Version = reader[nameof(MigrationsHistoryTable.Version)].ToSafeString();
            Version2 = reader[nameof(MigrationsHistoryTable.Version2)].ToSafeString();
        }
    }
}
