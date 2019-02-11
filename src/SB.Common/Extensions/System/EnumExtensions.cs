using SB.Common.Logics.SynonymProviders;
using System;

namespace SB.Common.Extensions.System
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string LocalizeString(this Enum enumValue)
        {
            return EnumSynonymProvider.Get(enumValue);
        }
    }
}
