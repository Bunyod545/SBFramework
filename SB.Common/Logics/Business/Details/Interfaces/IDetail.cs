using SBCommon.Logics.Metadata;

namespace SBCommon.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBDetailType))]
    public interface IDetail : IIdentifiedTyped
    {
        /// <summary>
        /// 
        /// </summary>
        long RowNumber { get; set; }
    }
}
