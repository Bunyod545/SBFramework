using SB.Common.Logics.SynonymProviders.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultSynonymStorage : ISynonymStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<SynonymInfo> Synonyms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static DefaultSynonymStorage()
        {
            Synonyms = new List<SynonymInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="synonymInfo"></param>
        public static void AddSynonym(SynonymInfo synonymInfo)
        {
            if(synonymInfo != null)
                Synonyms.Add(synonymInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static SynonymInfo GetInfo(Enum item)
        {
            var key = EnumSynonymProviderHelper.GetEnumKey(item);
            return GetInfo(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static SynonymInfo GetInfo(string key)
        {
            return Synonyms.FirstOrDefault(f => f.Key == key);
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
            if (Synonyms == null)
                return key;

            cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;
            var synonymInfo = Synonyms.ToList().FirstOrDefault(f => f.Key == key);
            if (synonymInfo == null)
                return key;

            if (Equals(CultureHelper.UzLanguage, cultureInfo))
                return synonymInfo.Uz;

            if (Equals(CultureHelper.RuLanguage, cultureInfo))
                return synonymInfo.Ru;

            if (Equals(CultureHelper.EnLanguage, cultureInfo))
                return synonymInfo.En;

            return key;
        }
    }
}
