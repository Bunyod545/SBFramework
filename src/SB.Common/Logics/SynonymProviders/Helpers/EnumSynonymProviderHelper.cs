using System;

namespace SB.Common.Logics.SynonymProviders.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumSynonymProviderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetEnumKey(Enum item)
        {
            if (item == null)
                return string.Empty;

            var type = item.GetType();
            var value = Enum.GetName(type, item);
            return $"{type.Name}.{value}";
        }
    }
}
