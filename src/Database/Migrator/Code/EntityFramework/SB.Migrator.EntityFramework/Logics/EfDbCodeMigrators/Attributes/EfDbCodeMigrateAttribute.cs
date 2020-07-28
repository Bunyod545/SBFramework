using System;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EfDbCodeMigrateAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public EfDbCodeMigrateAttribute(string version)
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
            var parseResult = System.Version.TryParse(version, out _);
            if (!parseResult)
                throw new ArgumentException($"Incorrect version: {version}", nameof(version));
        }
    }
}
