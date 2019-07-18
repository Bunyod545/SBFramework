using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlCreatePrimaryKeyCommand : MySqlPrimaryKeyCommand, ICreatePrimaryKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreatePrimaryKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append($"{PrimaryKey.Table.Schema}.`{PrimaryKey.Table.Name}`");

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append($" {GetPrimaryKeyName()}");
            ScriptBuilder.Append(" PRIMARY KEY");
            ScriptBuilder.Append($"(`{PrimaryKey.PrimaryColumn.Name}`)");
        }
    }
}
