namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOwned : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        IEntity Owner { get; set; }
    }
}
