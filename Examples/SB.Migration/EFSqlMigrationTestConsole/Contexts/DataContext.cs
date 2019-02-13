﻿using EFSqlMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using SB.EntityFramework;
using SB.EntityFramework.Context;

namespace EFSqlMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SBMigration]
    public class DataContext : EFContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<City> Cities { get; set; }

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