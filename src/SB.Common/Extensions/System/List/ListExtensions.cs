using SB.Common.Extensions.System.List;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Extensions
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
        /// <param name="action"></param>
        public static void ForEach<T>(this List<T> list, Action<T, IterationArgs> action)
        {
            var args = new IterationArgs();
            args.Count = list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                args.Index = i;
                action(list[i], args);

                if (args.IsBreak)
                    break;
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static void AddUnique<T>(this List<T> list, T item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static bool IsNotLast<T>(this List<T> list, T item)
        {
            return !list.IsLast(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static bool IsLast<T>(this List<T> list, T item)
        {
            return ReferenceEquals(list.LastOrDefault(), item);
        }
    }
}
