using SBCommon.Logics.Business;
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
        public Periodicity Periodicity { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBDocumentType(long typeId, Type clrType) : base(typeId, clrType)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {

        }
    }
}
