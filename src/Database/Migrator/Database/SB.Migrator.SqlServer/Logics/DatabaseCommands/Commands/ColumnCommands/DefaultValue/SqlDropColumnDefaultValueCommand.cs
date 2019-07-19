using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropColumnDefaultValueCommand : SqlColumnDefaultValueCommand, IDropColumnDefaultValueCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropColumnDefaultValue;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.AppendFormat(Table.GetSqlName());

            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append(GetConstraintName());
        }
    }
}
