namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SBObjectBase : IIdentifiedTyped
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TypeId => GetTypeId();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract long GetTypeId();
    }
}
