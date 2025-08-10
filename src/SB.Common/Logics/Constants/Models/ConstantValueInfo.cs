using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantValueInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ConstantId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantInfo Constant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantValueInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ConstantValueInfo(string value)
        {
            Value = value;
        }
    }
}