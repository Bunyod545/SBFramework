﻿namespace SB.Migrator.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseCreator
    {
        /// <summary>
        /// 
        /// </summary>
        IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsDatabaseExists();

        /// <summary>
        /// 
        /// </summary>
        void CreateDatabase();
    }
}