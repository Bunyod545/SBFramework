using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlAfterActualizationScriptCommand : MySqlScriptCommand, IAfterActualizationScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.AfterActualization;
    }
}
