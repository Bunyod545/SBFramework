using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlAfterActualizationScriptCommand : SqlScriptCommand, IAfterActualizationScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.AfterActualization;
    }
}
