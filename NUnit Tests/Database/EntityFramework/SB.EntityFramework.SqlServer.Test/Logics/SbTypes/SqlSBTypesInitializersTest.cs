using System.Linq;
using NUnit.Framework;
using SB.EntityFramework.Context.Tables;
using SBCommon.Logics.Metadata;

namespace SB.EntityFramework.SqlServer.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlSBTypesInitializersTest
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void InitializeContext()
        {
            var context = new SqlTestContext();
            var types = context.SbTypes.ToList();
            types.ForEach(f => context.SbTypes.Remove(f));

            TableFinder.GetTypeInfos(typeof(SqlTestContext));
            TableFinder.CacheTypeInfos.RemoveAll(r => r.ClrType == typeof(SbType));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MigrateTest()
        {
            var context = new SqlTestContext();
            context.Add(Country.GetSbType());
            context.SaveChanges();

            SBType.Initializer = new SqlSBTypesInitializers(context);
            SBType.InitializeTypes();

            var employeeType = SBType.GetType<Employee>();
            Assert.NotNull(employeeType);
        }
    }
}
