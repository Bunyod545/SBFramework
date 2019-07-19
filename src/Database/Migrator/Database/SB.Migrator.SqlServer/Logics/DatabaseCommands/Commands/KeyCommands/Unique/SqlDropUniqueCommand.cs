using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropUniqueCommand : SqlUniqueKeyCommand, IDropUniqueKeyCommand
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
            ScriptBuilder.Append($"ALTER TABLE {Table.GetSqlName()} DROP CONSTRAINT {GetUniqueName()};");
        }
    }
}
