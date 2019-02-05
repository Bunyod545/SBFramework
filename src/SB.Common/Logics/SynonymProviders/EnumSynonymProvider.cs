using System;
using System.Globalization;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumSynonymProvider
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

            var type = item.GetType();
            var value = Enum.GetName(type, item);

            return SynonymStorage?.Get($"{type.Name}.{value}", cultureInfo) ?? value;
        }
    }
}
