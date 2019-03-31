using System;
using SB.Common.Logics.Business.Types.Documents;
using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDocumentType))]
    public abstract class Document : SBObject, IDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual DateTime PeriodicDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BeforeSubmit()
        {
            PeriodicDate = DocumentTimeStampHelper.GetPeriodicDate(this);
        }
    }
}
