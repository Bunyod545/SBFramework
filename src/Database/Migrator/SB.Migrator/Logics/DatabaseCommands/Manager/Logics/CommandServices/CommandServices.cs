using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandServices
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<CommandServiceInfo> _serviceInfos;

        /// <summary>
        /// 
        /// </summary>
        public CommandServices()
        {
            _serviceInfos = new List<CommandServiceInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TCommand"></typeparam>
        public void Add<T, TCommand>()
            where T : IDatabaseCommand
            where TCommand : IDatabaseCommand
        {
            var service = new CommandServiceInfo();
            service.CommandType = typeof(T);
            service.CommandImplementType = typeof(TCommand);

            _serviceInfos.Add(service);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Remove<T>() where T : IDatabaseCommand
        {
            _serviceInfos.RemoveAll(r => r.CommandType == typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetServices()
        {
            _serviceInfos.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCommand<T>() where T : class, IDatabaseCommand
        {
            var service = _serviceInfos.FirstOrDefault(f => f.CommandType == typeof(T));
            if (service == null)
                return null;

            return (T) Activator.CreateInstance(service.CommandImplementType);
        }
    }
}
