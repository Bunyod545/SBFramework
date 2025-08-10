using SB.Common.Logics.Business;
using System;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBDocumentType : SBType
    {
        /// <summary>
        /// 
        /// </summary>
        public Periodicity Periodicity { get; set; } = Periodicity.Year;
    }
}
