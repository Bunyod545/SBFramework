using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlBeforeActualizationScriptCommand : MySqlScriptCommand, IBeforeActualizationScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.BeforeActualization;
    }
}
