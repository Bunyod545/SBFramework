namespace SBCommon.Logics.Business.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Document : IDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual long TypeId { get; }
    }
}
