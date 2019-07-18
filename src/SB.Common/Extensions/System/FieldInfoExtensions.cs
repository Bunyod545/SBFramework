using System.Reflection;
using SB.Common.Logics.Summary;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class FieldInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this FieldInfo fieldInfo) where T : Attribute
        {
            return fieldInfo.GetCustomAttribute<T>() != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        public static string GetSummary(this FieldInfo fieldInfo)
        {
            return SummaryManager.GetSummary(fieldInfo);
        }
    }
}
