using System;
using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business
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
        protected DateTime PeriodicDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BeforeSubmit()
        {

        }
    }
}
