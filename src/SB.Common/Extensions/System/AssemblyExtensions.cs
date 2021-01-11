using System.IO;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetAssemblyXmlDocumentPath(this Assembly assembly)
        {
            var uri = new UriBuilder(assembly.CodeBase);
            var dllPath = Uri.UnescapeDataString(uri.Path);

            return dllPath.Substring(0, dllPath.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetAssemblyPath(this Assembly assembly)
        {
            var uri = new UriBuilder(assembly.CodeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
    }
}
