using System;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clrType"></param>
        public TypeInfo(Type clrType)
        {
            ClrType = clrType;
        }
    }
}
