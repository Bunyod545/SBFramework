using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDetailType))]
    public class Detail : SBObject, IDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long RowNumber { get; set; }
    }
}
