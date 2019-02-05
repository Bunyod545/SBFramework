using NUnit.Framework;
using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SynonymProviderTest
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void InitializeSynonymProvider()
        {
            var synonym = new SynonymInfo(nameof(SynonymProviderTest));
            synonym.Uz = nameof(SynonymProviderTest) + nameof(SynonymInfo.Uz);
            synonym.En = nameof(SynonymProviderTest) + nameof(SynonymInfo.En);
            synonym.Ru = nameof(SynonymProviderTest) + nameof(SynonymInfo.Ru);

            DefaultSynonymStorage.AddSynonym(synonym);
            SynonymProvider.SynonymStorage = new DefaultSynonymStorage();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetSynonymTest()
        {
            var synonym = SynonymProvider.Get(typeof(SynonymProviderTest), CultureHelper.UzLanguage);
            Assert.AreEqual(synonym, nameof(SynonymProviderTest) + nameof(SynonymInfo.Uz));

            synonym = SynonymProvider.Get(typeof(SynonymProviderTest), CultureHelper.EnLanguage);
            Assert.AreEqual(synonym, nameof(SynonymProviderTest) + nameof(SynonymInfo.En));

            synonym = SynonymProvider.Get(typeof(SynonymProviderTest), CultureHelper.RuLanguage);
            Assert.AreEqual(synonym, nameof(SynonymProviderTest) + nameof(SynonymInfo.Ru));
        }
    }
}
