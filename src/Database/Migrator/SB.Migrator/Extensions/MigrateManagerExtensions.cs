using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrateManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public static void UseSafeMode(this MigrateManager manager)
        {
            var services = manager?.DatabaseCommandManager?.CommandServices;
            if (services == null)
                return;

            services.Remove<IDropTableCommand>();
            services.Remove<IDropColumnCommand>();
            services.Remove<IDropForeignKeyCommand>();
            services.Remove<IDropPrimaryKeyCommand>();
            services.Remove<IDropColumnDefaultValueCommand>();
        }
    }
}
