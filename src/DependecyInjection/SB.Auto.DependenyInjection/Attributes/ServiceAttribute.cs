using System;

namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public ServiceLifeCycle LifeCycle { get; set; }
    }
}
