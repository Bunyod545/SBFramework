using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlCreateColumnDefaultValueCommand : MySqlColumnDefaultValueCommand, ICreateColumnDefaultValueCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateColumnDefaultValue;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append(Table.GetMySqlName());

            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append(GetConstraintName());

            ScriptBuilder.Append(" DEFAULT");
            ScriptBuilder.Append($" ({Column.DefaultValue})");

            ScriptBuilder.Append(" FOR");
            ScriptBuilder.Append($" {Column.GetMySqlName()}");
        }
    }
}
