using System;

namespace SB.Common.Logics.Metadata.BusinessTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class SBEnumType : SBType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBEnumType(long typeId, Type clrType) : base(typeId, clrType)
        {
        }
    }
}
