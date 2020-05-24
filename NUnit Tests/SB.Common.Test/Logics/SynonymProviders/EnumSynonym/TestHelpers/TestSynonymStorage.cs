using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SB.Common.Logics.SynonymProviders;
using SB.Common.Logics.SynonymProviders.Logics.SynonymCulture;

namespace SB.Common.Test.Logics.SynonymProviders.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestSynonymStorage : ISynonymStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TestEnumSynonymInfo> SynonymInfos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ISynonymCultureService CultureService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfos"></param>
        public TestSynonymStorage(List<TestEnumSynonymInfo> synonymInfos)
        {
            SynonymInfos = synonymInfos;
            CultureService = new SynonymCultureService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return Get(key, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public string Get(string key, CultureInfo cultureInfo)
        {
            var synonym = SynonymInfos.FirstOrDefault(f => f.Key == key);
            if (synonym == null)
                return null;

            if (Equals(cultureInfo, CultureHelper.EnLanguage))
                return synonym.En;

            if (Equals(cultureInfo, CultureHelper.RuLanguage))
                return synonym.Ru;

            if (Equals(cultureInfo, CultureHelper.UzLanguage))
                return synonym.Uz;

            return key;
        }
    }
}
