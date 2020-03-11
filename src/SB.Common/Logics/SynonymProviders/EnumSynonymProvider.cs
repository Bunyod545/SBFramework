using SB.Common.Logics.SynonymProviders.Helpers;
using System;
using System.Globalization;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumSynonymProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISynonymStorage SynonymStorage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static EnumSynonymProvider()
        {
            SynonymStorage = new DefaultSynonymStorage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Get(Enum item)
        {
            return Get(item, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string Get(Enum item, CultureInfo cultureInfo)
        {
            if (item == null)
                return string.Empty;

            var key = EnumSynonymProviderHelper.GetEnumKey(item);
            return SynonymStorage?.Get(key, cultureInfo) ?? key;
        }
    }
}
