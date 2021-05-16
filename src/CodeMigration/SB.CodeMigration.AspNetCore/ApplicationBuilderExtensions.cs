using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SB.CodeMigration.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="actualVersion"></param>
        public static void UseCodeMigration(this IApplicationBuilder app)
        {
            var scopeFactory = (IServiceScopeFactory)app.ApplicationServices.GetService(typeof(IServiceScopeFactory));
            var scope = scopeFactory.CreateScope();

            var defaultOptions = new CodeMigrationDefaultOptions();
            defaultOptions.Activator = new CodeMigrationDIActivator(scope.ServiceProvider);

            var versionManager = (ICodeMigrationVersionManager)app.ApplicationServices.GetService(typeof(ICodeMigrationVersionManager));
            if (versionManager == null)
                throw new Exception("ICodeMigrationVersion manager not registered to DI");

            CodeMigrationManager.Migrate(versionManager, defaultOptions);
            scope.Dispose();
        }
    }
}
