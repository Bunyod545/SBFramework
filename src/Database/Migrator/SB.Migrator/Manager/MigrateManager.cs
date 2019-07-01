using System;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public class MigrateManager : IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public event MigrateBeginHandler MigrateBegin;

        /// <summary>
        /// 
        /// </summary>
        public event MigrateEndHandler MigrateEnd;

        /// <summary>
        /// 
        /// </summary>
        public IMigrateValidator Validator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICodeTablesManager CodeTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDatabaseTablesManager DatabaseTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDatabaseCommandManager DatabaseCommandManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDatabaseCreator DatabaseCreator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IMigrationsHistoryRepository MigrationsHistoryRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public MigrateManager(string connectionString)
        {
            ConnectionString = connectionString;
            DatabaseCommandManager = new DatabaseCommandManager(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            if (Validator == null)
                throw new ArgumentNullException(nameof(Validator));

            Validator.Valid();
            CheckAndCreateDatabase();

            OnMigrateBegin();
            InitializeManagers();

            if (Validator.IsActual())
            {
                OnMigrateEnd();
                return;
            }

            InternalMigrate();
            OnMigrateEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckAndCreateDatabase()
        {
            if (!DatabaseCreator.IsDatabaseExists())
                DatabaseCreator.CreateDatabase();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitializeManagers()
        {
            CodeTablesManager.Initialize();
            DatabaseTablesManager.Initialize();
            DatabaseCommandManager.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InternalMigrate()
        {
            var codeTables = CodeTablesManager.GetTableInfos();
            var databaseTables = DatabaseTablesManager.GetTableInfos();

            DatabaseCommandManager.MergeTables(codeTables, databaseTables);
            DatabaseCommandManager.Migrate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnMigrateBegin()
        {
            MigrateBegin?.Invoke(this);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnMigrateEnd()
        {
            MigrateEnd?.Invoke(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static MigrateManager Create(string connectionString)
        {
            return new MigrateManager(connectionString);
        }
    }
}
