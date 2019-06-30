using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresBeforeActualizationScriptCommand : PostgresScriptCommand, IBeforeActualizationScriptCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.BeforeActualization;
    }
}
