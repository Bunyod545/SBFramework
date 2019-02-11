using NUnit.Framework;
using SB.Common.Test.Logics.Metadata.Initializers;
using SB.Common.Test.Logics.Metadata.Tables;
using SB.Common.Test.Logics.Metadata.Types;
using SB.Common.Logics.Metadata;

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
        [SetUp]
        public void InitializeMetadata()
        {
            SBType.Initializer = new SBTypeTestInitializer();
            SBType.InitializeTypes();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MetadataTestEntity()
        {
            var country = new CountryTestEntity();
            Assert.AreEqual(country.TypeId, 1);

            var countryType = SBType.GetType(country);
            Assert.IsInstanceOf<SBEntityType>(countryType);

            var city = new CityTestEntity();
            Assert.AreEqual(city.TypeId, 2);

            var cityType = SBType.GetType(city);
            Assert.IsInstanceOf<CitySBType>(cityType);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MetadataTestDetail()
        {
            var tab = new TabTestDetail();
            Assert.AreEqual(tab.TypeId, 3);

            var tabType = SBType.GetType(tab);
            Assert.IsInstanceOf<SBDetailType>(tabType);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MetadataTestDocument()
        {
            var document = new MovementDocument();
            Assert.AreEqual(document.TypeId, 4);

            var documentType = SBType.GetType(document);
            Assert.IsInstanceOf<SBDocumentType>(documentType);
        }
    }
}
