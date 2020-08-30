using System.Collections.Generic;
using System.Linq;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> items, int count)
        {
            return items.Take(items.Count() - count);
        }
    }
}
