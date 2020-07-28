using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using SB.Common.Helpers;

namespace SB.Migrator.ResourceScript
{
    /// <summary>
    /// 
    /// </summary>
    public static class ResourceScriptsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<ScriptMetadata> GetBeforeActualizationScripts(Assembly assembly)
        {
            var attr = assembly.GetCustomAttribute<BeforeActualizationAttribute>();
            if (attr == null)
                return new List<ScriptMetadata>();

            var resource = GetResourceName(attr.ResourceFile, assembly);
            return GetScripts(resource, assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<ScriptMetadata> GetAfterActualizationScripts(Assembly assembly)
        {
            var attr = assembly.GetCustomAttribute<AfterActualizationAttribute>();
            if (attr == null)
                return new List<ScriptMetadata>();

            var resource = GetResourceName(attr.ResourceFile, assembly);
            return GetScripts(resource, assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static string GetResourceName(string name, Assembly assembly)
        {
            var files = assembly.GetManifestResourceNames().ToList();
            var resources = files.Where(w => w.EndsWith(name)).ToList();
            if (resources.Count > 1)
                throw new Exception($"Multiple resource file found with same name: {name}");

            return resources.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static List<ScriptMetadata> GetScripts(string resource, Assembly assembly)
        {
            if (string.IsNullOrEmpty(resource))
                return new List<ScriptMetadata>();

            var stream = assembly.GetManifestResourceStream(resource);
            if (stream == null)
                return new List<ScriptMetadata>();

            var resourceReader = new ResourceReader(stream);
            var entrys = resourceReader.Cast<DictionaryEntry>().ToList();
            return entrys.Select(GetScript).Where(w => w != null).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private static ScriptMetadata GetScript(DictionaryEntry entry)
        {
            if (!(entry.Key is string fileName))
                return null;

            var version = GetVersionFromFileName(fileName);
            if (version == null)
                return null;

            if (!(entry.Value is string script))
                return null;

            if (string.IsNullOrEmpty(script))
                return null;

            var scriptMetadata = new ScriptMetadata();
            scriptMetadata.FileName = fileName;
            scriptMetadata.VersionString = version.ToString();
            scriptMetadata.Version = version;
            scriptMetadata.ScriptText = script;

            return scriptMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Version GetVersionFromFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var index = fileName.IndexOf(Strings.BottomLine, StringComparison.InvariantCulture);
            if (index == -1)
                return null;

            var versionString = fileName.Substring(0, index);
            return !Version.TryParse(versionString, out var version) ? null : version;
        }
    }
}
