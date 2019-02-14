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
        public MigrateManager()
        {
            DatabaseCommandManager = new DatabaseCommandManager();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            Validate();

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
            if(CodeTablesManager == null)
                throw new ArgumentNullException(nameof(CodeTablesManager));

            if (DatabaseTablesManager == null)
                throw new ArgumentNullException(nameof(DatabaseTablesManager));

            if (DatabaseCommandManager == null)
                throw new ArgumentNullException(nameof(DatabaseCommandManager));
        }
    }
}
