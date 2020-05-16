using System;

namespace SB.Migrator.Metadata.Logics.DbCodeMigrators.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class DbCodeMigrateAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public DbCodeMigrateAttribute(string version)
        {
            Validate(version);
            Version = version;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void Validate(string version)
        {
            var parseResult = System.Version.TryParse(version, out var versionResult);
            if (!parseResult)
                throw new ArgumentException($"Incorrect version: {version}", nameof(version));
        }
    }
}
