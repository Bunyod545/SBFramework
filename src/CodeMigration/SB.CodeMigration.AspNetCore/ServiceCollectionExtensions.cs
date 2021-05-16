using Microsoft.Extensions.DependencyInjection;

namespace SB.CodeMigration.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddCodeMigration<TMigrationVersionManager>(this IServiceCollection services) where TMigrationVersionManager : class, ICodeMigrationVersionManager
        {
            services.AddScoped<ICodeMigrationVersionManager, TMigrationVersionManager>();
        }
    }
}
