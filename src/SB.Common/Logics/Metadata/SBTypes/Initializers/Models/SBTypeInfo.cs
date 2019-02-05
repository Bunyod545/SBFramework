using System;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public long TypeId { get; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; }

        /// <summary>
        /// 
        /// </summary>
        public SBTypeInfo()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBTypeInfo(long typeId, Type clrType)
        {
            TypeId = typeId;
            ClrType = clrType;
        }
    }
}
