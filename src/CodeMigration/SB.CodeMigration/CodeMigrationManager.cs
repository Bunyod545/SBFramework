using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public static class CodeMigrationManager
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionManager"></param>
        public static void Migrate(ICodeMigrationVersionManager versionManager)
        {
            Migrate(versionManager, new CodeMigrationDefaultOptions());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionManager"></param>
        /// <param name="options"></param>
        public static void Migrate(ICodeMigrationVersionManager versionManager, ICodeMigrationOptions options)
        {
            var actualVersion = versionManager.GetVersion();
            options.Logger.Log($"Code migration begin with actualVersion: {actualVersion}");

            var migrators = GetMigrators(options);
            options.Logger.Log($"Find {migrators.Count} migrations");

            var notMigratedMigrators = migrators
                .Where(w => w.MigratorVersion > actualVersion)
                .OrderBy(o => o.MigratorVersion)
                .ToList();

            options.Logger.Log($"Find {notMigratedMigrators.Count} not migrated migrations");
            notMigratedMigrators.ForEach(f => Migrate(f, versionManager, options));

            options.Logger.Log($"Code migration finished with actualVersion: {actualVersion}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<CodeMigratorInfo> GetMigrators(ICodeMigrationOptions options)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes());

            var migratorInterface = typeof(ICodeMigrator);
            var migratorTypes = types.Where(w =>
                migratorInterface.IsAssignableFrom(w) &&
                !w.IsAbstract &&
                !w.IsInterface &&
                Attribute.IsDefined(w, options.AttributeType)
            );

            return migratorTypes
                .Select(s => GetMigrator(s, options.AttributeType))
                .Where(w => w != null)
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migratorType"></param>
        /// <returns></returns>
        private static CodeMigratorInfo GetMigrator(Type migratorType, Type attributeType)
        {
            var attr = migratorType.GetCustomAttribute(attributeType) as CodeMigrationAttribute;
            if (attr == null)
                return null;

            var info = new CodeMigratorInfo();
            info.MigratorVersion = Version.Parse(attr.Version);
            info.MigratorType = migratorType;

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="versionManager"></param>
        /// <param name="options"></param>
        private static void Migrate(CodeMigratorInfo info, ICodeMigrationVersionManager versionManager, ICodeMigrationOptions options)
        {
            options.Logger.Log($"Code migrator type {info.MigratorType} activate begin, with version {info.MigratorVersion}");
            var migrator = options.Activator.Activate(info.MigratorType);
            options.Logger.Log($"Code migrator type {info.MigratorType} activate end, with version {info.MigratorVersion}");

            options.Logger.Log($"Code migrator type {info.MigratorType} migrate begin, with version {info.MigratorVersion}");
            migrator.Migrate();
            options.Logger.Log($"Code migrator type {info.MigratorType} migrate end, with version {info.MigratorVersion}");

            versionManager.SetVersion(info.MigratorVersion);
        }
    }
}
