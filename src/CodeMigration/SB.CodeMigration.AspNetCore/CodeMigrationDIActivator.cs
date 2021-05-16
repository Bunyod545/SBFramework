using System;
using System.Linq;

namespace SB.CodeMigration.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeMigrationDIActivator : ICodeMigrationActivator
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public CodeMigrationDIActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migratorType"></param>
        /// <returns></returns>
        public ICodeMigrator Activate(Type migratorType)
        {
            var ctors = migratorType.GetConstructors();
            if (ctors.Length == 0)
                throw new Exception($"Cannot find any public constructor for {migratorType}");

            if (ctors.Length > 1)
                throw new Exception($"More public constructors for {migratorType}");

            var ctor = ctors.FirstOrDefault();
            var ctorParamsInfos = ctor.GetParameters();

            var ctorParams = new object[ctorParamsInfos.Length];
            for (int index = 0; index < ctorParamsInfos.Length; index++)
            {
                var ctorParamInfo = ctorParamsInfos[index];
                ctorParams[index] = _serviceProvider.GetService(ctorParamInfo.ParameterType);
            }

            return (ICodeMigrator)Activator.CreateInstance(migratorType, ctorParams);
        }
    }
}
