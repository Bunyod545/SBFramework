﻿using SB.EntityFramework.Context;
using SB.Common.Logics.Application;

namespace SB.EntityFramework.Logics.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class EFDatabase : ISBDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            EFContext.SbDatabase = this;
            SBMigrationManager.Migrate();
        }
    }
}
