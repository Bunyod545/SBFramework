using SBCommon.Logics.Business.Base.Interfaces;

namespace SBCommon.Logics.Business.Details
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDetail : IIdentifiedTyped
    {
        /// <summary>
        /// 
        /// </summary>
        long RowNumber { get; set; }
    }
}
