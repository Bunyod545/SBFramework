using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using EFSqlMigrationTestConsole.Contexts.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.EntityFramework;

namespace EFSqlMigrationTestConsole.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [SbMigration("1.0.0.0")]
    public class SecondDataContext : FirstDataContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes().ToList();
            entities.ForEach(f => SetTableName(modelBuilder, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="entity"></param>
        protected virtual void SetTableName(ModelBuilder modelBuilder, IMutableEntityType entity)
        {
            var typeBuilder = modelBuilder.Entity(entity.ClrType);
            var attr = entity.ClrType.GetCustomAttribute<TableAttribute>();
            if (attr == null)
                throw new NotImplementedException($"{entity.ClrType} not marked with {nameof(TableAttribute)}");

            typeBuilder.ToTable(attr.Name);
        }
    }
}