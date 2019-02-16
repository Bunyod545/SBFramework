using System.Collections.Generic;
using SB.Migrator.Models.MigrationHistorys;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMigrationsHistoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<MigrationHistory> GetMigrationHistories();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        MigrationHistory GetMigrationHistory(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        void SetVersion(string name, string version);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version2"></param>
        void SetVersion2(string name, string version2);
    }
}