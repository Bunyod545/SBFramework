using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
    {
        /// <summary>
        /// 
        /// </summary>
        internal static List<SBType> CacheList { get; }

        /// <summary>
        /// 
        /// </summary>
        static SBType()
        {
            CacheList = new List<SBType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        internal static void AddToCache(SBType type)
        {
            lock (CacheList)
                InternalAddToCache(type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private static void InternalAddToCache(SBType type)
        {
            var cacheType = CacheList.Any(a => a.TypeId == type.TypeId);
            if (!cacheType)
                CacheList.Add(type);
        }
    }
}
