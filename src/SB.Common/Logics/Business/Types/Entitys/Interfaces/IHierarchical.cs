namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHierarchical : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IHierarchical Parent { get; set; }
    }
}
