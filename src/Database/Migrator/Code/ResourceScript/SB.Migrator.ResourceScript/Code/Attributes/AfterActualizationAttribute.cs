using System;

namespace SB.Migrator.ResourceScript
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AfterActualizationAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string ResourceFile { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFile"></param>
        public AfterActualizationAttribute(string resourceFile)
        {
            ResourceFile = resourceFile;
        }
    }
}
