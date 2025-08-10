using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDetailType))]
    public abstract class Detail : SBObject, IDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long RowNumber { get; set; }
    }
}
