using System;
using SBCommon.Logics.Metadata;

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
        bool ISBApplication.IsInitialized => IsInitialized;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ISBDatabase Database { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ISBTypesInitializer TypesInitializer { get; set; }

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
            Validate();
            Database.Initialize();
            SBType.InitializeTypes(TypesInitializer);

            IsInitialized = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Validate()
        {
            if (IsInitialized)
                throw new Exception("Application already initialized!");

            if (Database == null)
                throw new ArgumentNullException(nameof(Database));

            if (TypesInitializer == null)
                throw new ArgumentNullException(nameof(TypesInitializer));
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
