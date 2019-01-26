using SBCommon.Logics.Business.Base.Abstract;

namespace SBCommon.Logics.Business.Details
{
    /// <summary>
    /// 
    /// </summary>
    public class Detail : SBObject, IDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long RowNumber { get; set; }
    }
}
