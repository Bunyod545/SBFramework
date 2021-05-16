using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeMigrationAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public CodeMigrationAttribute(string version)
        {
            Version = version;
        }
    }
}
