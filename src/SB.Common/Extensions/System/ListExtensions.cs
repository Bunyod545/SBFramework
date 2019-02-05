using System;
using System.Collections.Generic;
using System.Linq;

namespace SBCommon.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this IEnumerable<T> items, Func<T, bool> expression)
        {
            return items.Where(expression).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this List<T> list, Action<T, int> action)
        {
            var index = 0;
            list.ForEach(f => action(f, index++));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
