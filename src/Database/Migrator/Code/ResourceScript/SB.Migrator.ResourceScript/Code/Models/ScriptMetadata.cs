using System;

namespace SB.Migrator.ResourceScript
{
    /// <summary>
    /// 
    /// </summary>
    public class ScriptMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public string VersionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ScriptText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MigrateName { get; set; }
    }
}
