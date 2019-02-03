using NUnit.Framework;
using SB.Common.Test.Logics.Metadata.Tables;
using SBCommon.Logics.Metadata;

namespace SB.Common.Test.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MetadataTest()
        {
            SBType.Initializer = new SBTypeTestInitializer();
            SBType.InitializeTypes();

            var country = new CountryTestEntity();
            Assert.AreEqual(country.TypeId, 1);

            var countryType = SBType.GetType(country);
            Assert.IsInstanceOf<SBEntityType>(countryType);

            var city = new CityTestEntity();
            Assert.AreEqual(city.TypeId, 2);

            var cityType = SBType.GetType(city);
            Assert.IsInstanceOf<CitySBType>(cityType);
        }
    }
}
