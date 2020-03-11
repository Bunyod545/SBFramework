using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.SynonymProviders.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTypeSynonymStorage : ISynonymStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TestTypeSynonymInfo> SynonymInfos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfos"></param>
        public TestTypeSynonymStorage(List<TestTypeSynonymInfo> synonymInfos)
        {
            SynonymInfos = synonymInfos;
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
