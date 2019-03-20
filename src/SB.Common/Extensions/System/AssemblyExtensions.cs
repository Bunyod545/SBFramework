using System.Reflection;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this Assembly assembly) where T : Attribute
        {
            return assembly.GetCustomAttribute<T>() != null;
        }
    }
}
