using System;
using SBCommon.Logics.Metadata;

namespace SB.Common.Test.Logics.Metadata.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class CitySBType : SBType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public CitySBType(long typeId, Type clrType) : base(typeId, clrType)
        {
        }
    }
}
