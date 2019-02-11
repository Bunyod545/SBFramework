using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISBApplication
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// 
        /// </summary>
        ISBDatabase Database { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ISBTypesInitializer TypesInitializer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Initialize();
    }
}
