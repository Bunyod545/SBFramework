using System;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SBType
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
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBType(long typeId, Type clrType)
        {
            TypeId = typeId;
            ClrType = clrType;
        }
    }
}
