using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDropColumnDefaultValueCommand : PostgresColumnDefaultValueCommand, IDropColumnDefaultValueCommand
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
            ScriptBuilder.AppendFormat("{0}.\"{1}\"", Column.Table.Schema, Column.Table.Name);

            ScriptBuilder.Append(" DROP CONSTRAINT");
            ScriptBuilder.Append(GetConstraintName());
        }
    }
}
