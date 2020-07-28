using System;

namespace SB.Migrator.ResourceScript
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class BeforeActualizationAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string ResourceFile { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFile"></param>
        public BeforeActualizationAttribute(string resourceFile)
        {
            ResourceFile = resourceFile;
        }
    }
}
