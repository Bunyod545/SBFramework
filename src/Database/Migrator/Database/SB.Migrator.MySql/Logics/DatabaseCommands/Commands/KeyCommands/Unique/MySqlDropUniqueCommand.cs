using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresDropUniqueCommand : MySqlUniqueKeyCommand, IDropUniqueKeyCommand
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
            ScriptBuilder.Append($"ALTER TABLE {Table.GetMySqlName()} DROP CONSTRAINT {UniqueName};");
        }
    }
}
