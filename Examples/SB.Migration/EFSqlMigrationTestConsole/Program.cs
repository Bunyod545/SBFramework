﻿using System;
using SB.Migrator;
using SB.Migrator.EntityFramework;
using SB.Migrator.SqlServer;

namespace EFSqlMigrationTestConsole
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConnectionString = "Server=MWI_91\\SQLSERVER2014;Database=TestEFSql;Trusted_Connection=True;";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MigrateManager.Create(ConnectionString)
                .UseSqlServerDatabase()
                .UseEfCodeTablesManager()
                .Migrate();

            Console.WriteLine("Migrate success");
            Console.ReadLine();
        }
    }
}