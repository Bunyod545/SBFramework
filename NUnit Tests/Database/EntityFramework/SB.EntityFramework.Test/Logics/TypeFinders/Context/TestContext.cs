using Microsoft.EntityFrameworkCore;
using SB.EntityFramework.Context;

namespace SB.EntityFramework.Test.Logics.TypeFinders.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class TestContext : EFContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<TestTable> TestTables { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<TestTableWithName> TestTableWithNames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<TestTableWithNameAndSchema> TestTableWithNameAndSchemas { get; set; }
    }
}
