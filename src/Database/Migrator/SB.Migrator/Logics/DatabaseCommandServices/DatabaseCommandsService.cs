using System;
using System.Collections.Generic;
using SB.Common.Extensions;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Logics.ServiceContainers;

namespace SB.Migrator.Logics.DatabaseCommandServices
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseCommandsService : IDatabaseCommandsService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Type> _registeredCommandTypes = new List<Type>();

        /// <summary>
        /// 
        /// </summary>
        private readonly IMigrateServicesContainer _servicesContainer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicesContainer"></param>
        public DatabaseCommandsService(IMigrateServicesContainer servicesContainer)
        {
            _servicesContainer = servicesContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        public void Register<TCommand>() where TCommand : class, IDatabaseCommand
        {
            _registeredCommandTypes.AddUnique(typeof(TCommand));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        public void UnRegister<TCommand>() where TCommand : class, IDatabaseCommand
        {
            _registeredCommandTypes.RemoveAll(r => r == typeof(TCommand));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        public TCommand GetCommand<TCommand>() where TCommand : class, IDatabaseCommand
        {
            var isExists = _registeredCommandTypes.Exists(t => t == typeof(TCommand));
            return isExists ? _servicesContainer.GetService<TCommand>() : null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _registeredCommandTypes.Clear();
        }
    }
}
