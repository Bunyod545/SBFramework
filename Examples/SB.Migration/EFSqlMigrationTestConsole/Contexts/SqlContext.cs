using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;

namespace EFSqlMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlContext : EFContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program.ConnectionString);
        }
    }
}
