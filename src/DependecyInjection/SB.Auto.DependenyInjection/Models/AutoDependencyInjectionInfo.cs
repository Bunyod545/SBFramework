using System;
using System.Collections.Generic;

namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoDependencyInjectionInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Type> BaseTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceLifeCycle LifeCycle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AutoDependencyInjectionInfo()
        {
            BaseTypes = new List<Type>();
        }
    }
}
