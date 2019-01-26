namespace SBCommon.Logics.Business.Base.Interfaces
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
