using NUnit.Framework;

namespace SB.Migrator.Metadata.Test.Logics.Metadata.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataEnumTablesHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetTableMetadataTest()
        {
            var metadata = MetadataEnumTablesHelper.GetTableMetadata(typeof(string));
            Assert.IsNull(metadata);

            metadata = MetadataEnumTablesHelper.GetTableMetadata(typeof(MonthsOfYear));
            Assert.IsNotNull(metadata);
        }
    }
}
