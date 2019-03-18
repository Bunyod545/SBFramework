using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlBeforeActualizationScriptCommand : SqlScriptCommand, IBeforeActualizationScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.BeforeActualization;
    }
}
