using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropForeignKeyCommand : SqlForeignKeyCommand, IDropForeignKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropForeignKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append(Table.GetSqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append($" {ForeignKeyName}");
        }
    }
}
