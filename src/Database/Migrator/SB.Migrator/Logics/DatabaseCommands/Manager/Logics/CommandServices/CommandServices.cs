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
        public List<CommandServiceInfo> ServiceInfos { get; }

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

            ServiceInfos.Add(service);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Remove<T>() where T : IDatabaseCommand
        {
            ServiceInfos.RemoveAll(r => r.CommandType == typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCommand<T>() where T : class, IDatabaseCommand
        {
            var service = ServiceInfos.FirstOrDefault(f => f.CommandType == typeof(T));
            if (service == null)
                return null;

            return (T) Activator.CreateInstance(service.CommandImplementType);
        }
    }
}
