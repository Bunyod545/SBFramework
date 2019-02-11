using System;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBEntityType : SBType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBEntityType(long typeId, Type clrType) : base(typeId, clrType)
        {

        }
    }
}
