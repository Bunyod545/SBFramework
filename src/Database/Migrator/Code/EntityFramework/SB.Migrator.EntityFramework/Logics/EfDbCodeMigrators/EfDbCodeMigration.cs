using SB.Migrator.Logics.ServiceContainers;

namespace SB.Migrator.EntityFramework.Logics
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EfDbCodeMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateServicesContainer ServicesContainer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected EfDbCodeMigration()
        {
            InitializeServices();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeServices()
        {
            TableMigrator = ServicesContainer.GetService<IEfDbCodeTableMigrator>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BeforeActualization()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void AfterActualization()
        {

        }
    }
}
