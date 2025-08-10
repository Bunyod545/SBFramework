using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class ConstantServiceAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ConstantServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        public ConstantServiceAttribute(Type serviceType)
        {
            ConstantServiceType = serviceType;
        }
    }
}