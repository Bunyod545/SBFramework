using SB.Common.Logics.SynonymProviders.Interfaces;
using System;
using System.Reflection;
using SB.Common.Logics.SynonymProviders.Logics;

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
        /// <returns></returns>
        public static string Get(Type type)
        {
           return Get($"{type.Name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static string Get(MemberInfo memberInfo)
        {
            return  Get($"{memberInfo.ReflectedType.Name}.{memberInfo.Name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return SynonymStorage?.Get(key) ?? key;
        }
    }
}
