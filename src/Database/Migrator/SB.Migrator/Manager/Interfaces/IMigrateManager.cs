using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;

namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        ICodeTablesManager CodeTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        IDatabaseTablesManager DatabaseTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        void Migrate();
    }
}
