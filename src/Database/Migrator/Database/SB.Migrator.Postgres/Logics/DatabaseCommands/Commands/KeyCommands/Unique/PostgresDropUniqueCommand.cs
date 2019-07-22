using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresDropUniqueCommand : PostgresUniqueKeyCommand, IDropUniqueKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropUniqueKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder.Append($"ALTER TABLE {Table.GetPgSqlName()} DROP CONSTRAINT {UniqueName};");
        }
    }
}
