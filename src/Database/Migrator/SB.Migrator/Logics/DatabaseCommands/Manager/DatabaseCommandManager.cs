using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database.Interfaces;
using SB.Migrator.Logics.DatabaseCommandServices;
using SB.Migrator.Logics.ServiceContainers;
using SB.Migrator.Models;
using SB.Migrator.Models.MigrationHistories;
using SB.Migrator.Models.Scripts;

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
        public IMigrateServicesContainer Container { get; }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseCommandsService CommandServices { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected List<IDatabaseCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseConnection DatabaseConnection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IMigrationsHistoryRepository HistoryRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected ICodeTablesManager CodeTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DatabaseCommandManager(IMigrateServicesContainer container)
        {
            Container = container;
            Commands = new List<IDatabaseCommand>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            CommandServices = Container.GetService<IDatabaseCommandsService>();
            DatabaseConnection = Container.GetService<IDatabaseConnection>();
            HistoryRepository = Container.GetService<IMigrationsHistoryRepository>();
            CodeTablesManager = Container.GetService<ICodeTablesManager>();
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
            Commands.ForEach(f => f.ConnectionString = DatabaseConnection.ConnectionString);
            Commands.ForEach(f => f.BuildCommandText());

            BeforeMigrate();
            ActualizationMigrate();
            AfterMigrate();

            CorrectMigrateVersions();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BeforeMigrate()
        {
            var beforeScripts = CodeTablesManager.GetBeforeActualizationScripts();
            beforeScripts = beforeScripts.OrderBy(o => o.Version).ToList();

            var beforeActualization = Container.GetService<IBeforeActualizationScriptCommand>();
            beforeActualization.ConnectionString = DatabaseConnection.ConnectionString;
            beforeScripts.ForEach(f => ExecuteBeforeMigrate(beforeActualization, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptCommand"></param>
        /// <param name="beforeScript"></param>
        private void ExecuteBeforeMigrate(IBeforeActualizationScriptCommand scriptCommand, ScriptInfo beforeScript)
        {
            scriptCommand.SetScript(beforeScript);
            scriptCommand.BuildCommandText();
            scriptCommand.Execute();

            HistoryRepository.SetVersion(beforeScript.MigrateName, beforeScript.Version.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void ActualizationMigrate()
        {
            var commands = Commands.OrderBy(o => o.Order).ToList();
            commands.ForEach(f => f.Execute());
        }

        /// <summary>
        /// 
        /// </summary>
        private void AfterMigrate()
        {
            var afterScripts = CodeTablesManager.GetAfterActualizationScripts();
            afterScripts = afterScripts.OrderBy(o => o.Version).ToList();

            var afterActualization = Container.GetService<IAfterActualizationScriptCommand>();
            afterActualization.ConnectionString = DatabaseConnection.ConnectionString;
            afterScripts.ForEach(f => ExecuteAfterMigrate(afterActualization, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptCommand"></param>
        /// <param name="afterScript"></param>
        private void ExecuteAfterMigrate(IAfterActualizationScriptCommand scriptCommand, ScriptInfo afterScript)
        {
            scriptCommand.SetScript(afterScript);
            scriptCommand.BuildCommandText();
            scriptCommand.Execute();

            HistoryRepository.SetVersion2(afterScript.MigrateName, afterScript.Version.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void CorrectMigrateVersions()
        {
            var actualVersions = CodeTablesManager.GetMigrationVersionInfos();
            actualVersions.ForEach(CorrectMigrateVersion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualVersionInfo"></param>
        private void CorrectMigrateVersion(MigrationVersionInfo actualVersionInfo)
        {
            var databaseHistory = HistoryRepository.GetMigrationHistory(actualVersionInfo.Name);
            if (databaseHistory == null)
            {
                HistoryRepository.InsertHistoryInfo(actualVersionInfo.Name, actualVersionInfo.Version);
                return;
            }

            if (!Version.TryParse(databaseHistory.Version, out var version))
                version = new Version();

            if (!Version.TryParse(databaseHistory.Version2, out var version2))
                version2 = new Version();

            if (!Version.TryParse(actualVersionInfo.Version, out var actualVersion))
                actualVersion = new Version();

            if (actualVersion > version)
                HistoryRepository.SetVersion(actualVersionInfo.Name, actualVersionInfo.Version);

            if (actualVersion > version2)
                HistoryRepository.SetVersion2(actualVersionInfo.Name, actualVersionInfo.Version);
        }
    }
}
