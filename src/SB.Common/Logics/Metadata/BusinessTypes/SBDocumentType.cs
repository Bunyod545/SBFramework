using System;

namespace SBCommon.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBDocumentType : SBType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBDocumentType(long typeId, Type clrType) : base(typeId, clrType)
        {
        }
    }
}
