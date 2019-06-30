using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models.MigrationHistorys;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresMigrationsHistoryRepository : IMigrationsHistoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        protected MigrationsHistoryRepositoryHelper Helper { get; }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsHistoryTableExists { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public PostgresMigrationsHistoryRepository(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
            Helper = new MigrationsHistoryRepositoryHelper(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MigrationHistory> GetMigrationHistories()
        {
            CheckHistoryTableExists();
            return Helper.GetMigrationHistories().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MigrationHistory GetMigrationHistory(string name)
        {
            CheckHistoryTableExists();
            return Helper.GetMigrationHistory(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void InsertHistoryInfo(string name, string version)
        {
            SetVersion(name, version);
            SetVersion2(name, version);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool CheckHistoryTableExists()
        {
            if (IsHistoryTableExists)
                return true;

            if (!Helper.IsHistoryTableExists())
                Helper.CreateHistoryTable();

            return IsHistoryTableExists = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public void SetVersion(string name, string version)
        {
            Helper.SetVersion(name, version);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version2"></param>
        public void SetVersion2(string name, string version2)
        {
            Helper.SetVersion2(name, version2);
        }
    }
}
