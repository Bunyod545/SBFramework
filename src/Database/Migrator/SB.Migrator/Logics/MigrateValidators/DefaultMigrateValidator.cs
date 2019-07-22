using System;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DefaultMigrateValidator : IMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        public MigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        protected DefaultMigrateValidator(MigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Valid()
        {
            if (MigrateManager.DatabaseCreator == null)
                throw new ArgumentNullException(nameof(MigrateManager.DatabaseCreator));

            if (MigrateManager.CodeTablesManager == null)
                throw new ArgumentNullException(nameof(MigrateManager.CodeTablesManager));

            if (MigrateManager.DatabaseTablesManager == null)
                throw new ArgumentNullException(nameof(MigrateManager.DatabaseTablesManager));

            if (MigrateManager.DatabaseCommandManager == null)
                throw new ArgumentNullException(nameof(MigrateManager.DatabaseCommandManager));

            if (MigrateManager.NamingManager == null)
                throw new ArgumentNullException(nameof(MigrateManager.NamingManager));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsActual();
    }
}
