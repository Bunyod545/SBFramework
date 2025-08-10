namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DbConstantContext
    {
        /// <summary>
        /// 
        /// </summary>
        public IConstantRepository ConstantRepository { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantRepository"></param>
        protected DbConstantContext(IConstantRepository constantRepository)
        {
            ConstantRepository = constantRepository;
            ConstantManager.Initialize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void SaveChanges()
        {
            ConstantRepository.SubmitChanges();
        }
    }
}