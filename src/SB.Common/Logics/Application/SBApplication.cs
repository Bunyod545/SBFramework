using System;

namespace SBCommon.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class SBApplication : ISBApplication
    {
        /// <summary>
        /// 
        /// </summary>
        public static SBApplication Current { get; private set; }

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
        private SBApplication()
        {
            Current = this;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISBApplication Create()
        {
            return Current ?? new SBApplication();
        }
    }
}
