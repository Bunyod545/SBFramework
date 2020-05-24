using System;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Logics.ServiceContainers;

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
        public IMigrateServicesContainer Container { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        protected DefaultMigrateValidator(IMigrateServicesContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Valid()
        {
            ValidateService<IDatabaseCreator>();
            ValidateService<ICodeTablesManager>();
            ValidateService<IDatabaseTablesManager>();
            ValidateService<IDatabaseCommandManager>();
            ValidateService<INamingManager>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        protected virtual void ValidateService<TService>() where TService : class
        {
            var service = Container.GetService<TService>();
            if (service == null)
                throw new ArgumentNullException(typeof(TService).Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsActual();
    }
}
