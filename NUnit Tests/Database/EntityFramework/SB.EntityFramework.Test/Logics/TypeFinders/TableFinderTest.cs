using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SB.EntityFramework.Context;
using SB.Migrator.EntityFramework;

namespace SB.EntityFramework.Test.Logics.TypeFinders
{
    /// <summary>
    /// 
    /// </summary>
    public class TableFinderTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test()
        {
            TableFinder.AddAssembly(Assembly.GetExecutingAssembly());
            var tables = new EFCodeTablesManager().GetTableInfos();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TableNameFromPropertyAndDefaultSchema()
        {
            var table = GetTypeInfo(typeof(TestTable));

            Assert.NotNull(table);
            Assert.AreEqual(table.Name, nameof(Context.TestContext.TestTables));
            Assert.AreEqual(table.Schema, EFContext.DefaultSchema);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TableNameAndDefaultSchema()
        {
            var table = GetTypeInfo(typeof(TestTableWithName));

            Assert.NotNull(table);
            Assert.AreEqual(table.Name, TestTableWithName.TableName);
            Assert.AreEqual(table.Schema, EFContext.DefaultSchema);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TableNameAndSchema()
        {
            var table = GetTypeInfo(typeof(TestTableWithNameAndSchema));

            Assert.NotNull(table);
            Assert.AreEqual(table.Name, TestTableWithNameAndSchema.TableName);
            Assert.AreEqual(table.Schema, TestTableWithNameAndSchema.Schema);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TypeInfo GetTypeInfo(Type clrType)
        {
            var typeInfos = TableFinder.InitalizeTypeInfos(typeof(Context.TestContext));
            Assert.AreEqual(3, typeInfos.Count);

            return typeInfos.FirstOrDefault(f=>f.ClrType == clrType);
        }
    }
}
