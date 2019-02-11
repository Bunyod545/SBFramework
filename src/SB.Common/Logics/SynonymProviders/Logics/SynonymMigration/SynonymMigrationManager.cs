using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using SB.Common.Extensions;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public static class SynonymMigrationManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISynonymMigrator SynonymMigrator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static List<SynonymPropertyInfo> PropertyInfos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static SynonymMigrationManager()
        {
            PropertyInfos = new List<SynonymPropertyInfo>();

            foreach (var property in typeof(SynonymInfo).GetProperties())
            {
                var attr = property.GetCustomAttribute<CultureInfoAttribute>();
                if (attr != null)
                    PropertyInfos.Add(new SynonymPropertyInfo(property, attr));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Register<T>()
        {
            SynonymMigrationFactory.Register<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void UnRegister<T>()
        {
            SynonymMigrationFactory.UnRegister<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Migrate<T>() where T : class, ISynonymMigrator
        {
            SynonymMigrator = Activator.CreateInstance<T>();
            if (SynonymMigrator == null)
                return;

            if (SynonymMigrator.IsActual())
                return;

            var synonymInfos = new List<SynonymInfo>();
            foreach (var type in SynonymMigrationFactory.SynonymTypes)
            {
                var manager = GetResourceManager(type);
                if (manager != null)
                    synonymInfos.AddRange(GetSynonymInfos(manager));
            }

            SynonymMigrator.Migrate(synonymInfos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private static ResourceManager GetResourceManager(Type type)
        {
            var property = type.GetProperty(nameof(ResourceManager),
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static);

            return property?.GetValue(null, null) as ResourceManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<SynonymInfo> GetSynonymInfos(ResourceManager resourceManager)
        {
            var keys = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
            foreach (DictionaryEntry entry in keys)
                yield return GetByKey(resourceManager, entry.Key.ToSafeString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SynonymInfo GetByKey(ResourceManager manager, string key)
        {
            var result = new SynonymInfo(key);
            foreach (var info in PropertyInfos)
                info.SetValue(result, manager.GetString(key, info.CultureInfo));

            return result;
        }
    }
}
