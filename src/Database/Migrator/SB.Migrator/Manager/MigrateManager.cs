using System;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.Database.Interfaces;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Logics.DatabaseCommandServices;
using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Logics.ServiceContainers;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MigrateManager : IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public IMigrateServicesContainer ServicesContainer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IMigrateValidator Validator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseCreator DatabaseCreator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseCommandManager DatabaseCommandManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseTablesManager DatabaseTablesManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected ICodeTablesManager CodeTablesManager { get; set; }

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
            ServicesContainer = new MigrateServicesContainer();
            InitializeDefaultServices();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void InitializeDefaultServices()
        {
            ServicesContainer.Register<IDatabaseConnection>(new DatabaseConnection(ConnectionString));
            ServicesContainer.Register(ServicesContainer);
            ServicesContainer.Register<IMigrateManager>(this);
            ServicesContainer.Register<IMigrateValidator, DefaultMigrateValidator>();
            ServicesContainer.Register<IDatabaseCommandManager, DatabaseCommandManager>();
            ServicesContainer.Register<INamingManager, DefaultNamingManager>();
            ServicesContainer.Register<IDatabaseCommandsService, DatabaseCommandsService>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            InitializeServiceProperties();
            if (Validator == null)
                throw new ArgumentNullException(nameof(Validator));

            Validator.Valid();
            CheckAndCreateDatabase();
            InitializeManagers();

            if (Validator.IsActual())
                return;

            OnMigrateBegin();
            InternalMigrate();
            OnMigrateEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitializeServiceProperties()
        {
            Validator = ServicesContainer.GetService<IMigrateValidator>();
            DatabaseCreator = ServicesContainer.GetService<IDatabaseCreator>();
            DatabaseCommandManager = ServicesContainer.GetService<IDatabaseCommandManager>();
            DatabaseTablesManager = ServicesContainer.GetService<IDatabaseTablesManager>();
            CodeTablesManager = ServicesContainer.GetService<ICodeTablesManager>();
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
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static MigrateManager Create(string connectionString)
        {
            return new MigrateManager(connectionString);
        }
    }
}
