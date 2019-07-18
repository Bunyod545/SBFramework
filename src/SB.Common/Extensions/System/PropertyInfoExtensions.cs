using System.Reflection;
using SB.Common.Logics.Summary;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this PropertyInfo property) where T : Attribute
        {
            return property.GetCustomAttribute<T>() != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetSummary(this PropertyInfo property)
        {
            return SummaryManager.GetSummary(property);
        }
    }
}
