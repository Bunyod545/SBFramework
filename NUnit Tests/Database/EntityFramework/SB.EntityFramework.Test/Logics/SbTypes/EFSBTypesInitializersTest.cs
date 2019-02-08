using System.Linq;
using NUnit.Framework;
using SB.EntityFramework.Context.Tables;
using SB.EntityFramework.Test.Logics.SbTypes.Context;
using SB.EntityFramework.Test.Logics.SbTypes.Context.Tables;
using SBCommon.Logics.Metadata;

namespace SB.EntityFramework.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSBTypesInitializersTest
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void InitializeContext()
        {
            var context = new EFTestContext();
            var types = context.SbTypes.ToList();
            types.ForEach(f => context.SbTypes.Remove(f));

            TableFinder.InitalizeTypeInfos(typeof(EFTestContext));
            TableFinder.CacheTypeInfos.RemoveAll(r => r.ClrType == typeof(SbType));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MigrateTest()
        {
            var context = new EFTestContext();
            context.Add(Country.GetSbType());
            context.Add(City.GetSbType());
            context.SaveChanges();

            SBType.Initializer = new EFSBTypesInitializers(context);
            SBType.InitializeTypes();

            var employeeType = SBType.GetType<Employee>();
            Assert.NotNull(employeeType);
        }
    }
}
