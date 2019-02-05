using System;

namespace SBCommon.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SBApplication
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ISBDatabase Database { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            if (IsInitialized)
                throw new Exception("Application already initialized!");

            Database?.Initialize();
            IsInitialized = true;
        }
    }
}
