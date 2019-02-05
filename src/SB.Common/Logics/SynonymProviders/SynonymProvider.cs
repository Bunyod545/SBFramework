using System;
using System.Globalization;
using System.Reflection;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class SynonymProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISynonymStorage SynonymStorage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static SynonymProvider()
        {
            SynonymStorage = new DefaultSynonymStorage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string Get(Type type, CultureInfo culture = null)
        {
            return Get($"{type.Name}", culture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string Get(MemberInfo memberInfo, CultureInfo culture = null)
        {
            return Get($"{memberInfo?.ReflectedType?.Name}.{memberInfo?.Name}", culture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string Get(string key, CultureInfo culture = null)
        {
            return SynonymStorage?.Get(key, culture) ?? key;
        }
    }
}
