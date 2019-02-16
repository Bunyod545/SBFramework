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
            Validate();

            if (!DatabaseCreator.IsDatabaseExists())
                DatabaseCreator.CreateDatabase();

            var codeTables = CodeTablesManager.GetTableInfos();
            var databaseTables = DatabaseTablesManager.GetTableInfos();

            DatabaseCommandManager.MergeTables(codeTables, databaseTables);
            DatabaseCommandManager.Migrate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Validate()
        {
            if (CodeTablesManager == null)
                throw new ArgumentNullException(nameof(CodeTablesManager));

            if (DatabaseTablesManager == null)
                throw new ArgumentNullException(nameof(DatabaseTablesManager));

            if (DatabaseCommandManager == null)
                throw new ArgumentNullException(nameof(DatabaseCommandManager));
        }
    }
}
