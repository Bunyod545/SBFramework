using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class MigrateAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public MigrateAttribute(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
