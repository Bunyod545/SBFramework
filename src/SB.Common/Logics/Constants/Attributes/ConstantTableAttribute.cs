using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class ConstantTableAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type TableType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        public ConstantTableAttribute(Type tableType)
        {
            TableType = tableType;
        }
    }
}