using SB.Migrator.Logics.ServiceContainers;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        IMigrateServicesContainer ServicesContainer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void Migrate();
    }
}
