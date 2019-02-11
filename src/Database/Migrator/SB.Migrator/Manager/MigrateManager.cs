using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MigrateManager : IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public ICodeTablesManager CodeTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public void Migrate()
        {
            Validate();

            var codeTables = CodeTablesManager.GetTableInfos();
            var databaseTables = DatabaseTablesManager.GetTableInfos();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Validate()
        {

        }
    }
}
