namespace SB.Common.Logics.Queue.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQueueIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        bool IsEqual(IQueueIdentifier identifier);
    }
}
