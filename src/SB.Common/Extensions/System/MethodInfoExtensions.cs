using System.Reflection;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this MethodInfo methodInfo) where T : Attribute
        {
            return methodInfo.GetCustomAttribute<T>() != null;
        }
    }
}
