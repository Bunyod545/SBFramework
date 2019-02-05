namespace SBCommon.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIdentifiedTyped : IIdentified
    {
        /// <summary>
        /// 
        /// </summary>
        long TypeId { get; }
    }
}
