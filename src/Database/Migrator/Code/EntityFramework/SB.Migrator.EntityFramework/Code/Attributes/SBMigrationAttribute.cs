using System;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class SbMigrationAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public SbMigrationAttribute(string version)
        {
            Version = version;
        }
    }
}
