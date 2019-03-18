using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager : IDatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandServices CommandServices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IMigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<IDatabaseCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        public IMigrationsHistoryRepository HistoryRepository => MigrateManager.MigrationsHistoryRepository;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseCommandManager(IMigrateManager migrateManager)
        {
            MigrateManager = migrateManager;
            CommandServices = new CommandServices();
            Commands = new List<IDatabaseCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeTables"></param>
        /// <param name="databaseTables"></param>
        public void MergeTables(List<TableInfo> codeTables, List<TableInfo> databaseTables)
        {
            Commands.Clear();

            codeTables.ForEach(f => MergeCodeTable(f, databaseTables));
            databaseTables.ForEach(f => MergeDatabaseTable(f, codeTables));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            BeforeMigrate();

            var commands = Commands.OrderBy(o => o.Order).ToList();
            commands.ForEach(f => f.Execute(MigrateManager.ConnectionString));

            AfterMigrate();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BeforeMigrate()
        {
            var beforeScripts = MigrateManager.CodeTablesManager.GetBeforeActualizationScripts();
            beforeScripts = beforeScripts.OrderBy(o => o.Version).ToList();

            var beforeActualization = CommandServices.GetCommand<IBeforeActualizationScriptCommand>();
            foreach (var beforeScript in beforeScripts)
            {
                beforeActualization.SetScript(beforeScript);
                beforeActualization.BuildCommandText();
                beforeActualization.Execute(MigrateManager.ConnectionString);
                HistoryRepository.SetVersion(beforeScript.MigrateName, beforeScript.Version.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AfterMigrate()
        {
            var afterScripts = MigrateManager.CodeTablesManager.GetAfterActualizationScripts();
            afterScripts = afterScripts.OrderBy(o => o.Version).ToList();

            var afterActualization = CommandServices.GetCommand<IAfterActualizationScriptCommand>();
            foreach (var afterScript in afterScripts)
            {
                afterActualization.SetScript(afterScript);
                afterActualization.BuildCommandText();
                afterActualization.Execute(MigrateManager.ConnectionString);
                HistoryRepository.SetVersion2(afterScript.MigrateName, afterScript.Version.ToString());
            }
        }
    }
}
