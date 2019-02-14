using System;
using System.Collections.Generic;
using System.Text;
using EFSqlMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework;

namespace EFSqlMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SBMigration]
    public class TestContext : SqlContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<City> Cities { get; set; }
    }
}
