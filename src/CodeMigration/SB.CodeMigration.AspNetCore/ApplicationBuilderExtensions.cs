using Microsoft.AspNetCore.Builder;
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
            var defaultOptions = new CodeMigrationDefaultOptions();
            defaultOptions.Activator = new CodeMigrationDIActivator(app.ApplicationServices);

            var versionManager = (ICodeMigrationVersionManager)app.ApplicationServices.GetService(typeof(ICodeMigrationVersionManager));
            if (versionManager == null)
                throw new Exception("ICodeMigrationVersion manager not registered to DI");

            CodeMigrationManager.Migrate(versionManager, defaultOptions);
        }
    }
}
