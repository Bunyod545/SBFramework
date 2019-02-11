namespace SB.Common.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISBDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Initialize();
    }
}
