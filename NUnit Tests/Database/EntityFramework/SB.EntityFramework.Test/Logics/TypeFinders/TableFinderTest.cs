using System.Linq;
using NUnit.Framework;
using SB.EntityFramework.Context;

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
        public void GetTypeInfos()
        {
            var typeInfos = TableFinder.GetTypeInfos(typeof(Context.TestContext));
            Assert.AreEqual(3, typeInfos.Count);

            var testTable = typeInfos.FirstOrDefault(f => f.ClrType == typeof(TestTable));
            Assert.NotNull(testTable);
            Assert.AreEqual(testTable.Name, nameof(Context.TestContext.TestTables));
            Assert.AreEqual(testTable.Schema, EFContext.DefaultSchema);
        }
    }
}
