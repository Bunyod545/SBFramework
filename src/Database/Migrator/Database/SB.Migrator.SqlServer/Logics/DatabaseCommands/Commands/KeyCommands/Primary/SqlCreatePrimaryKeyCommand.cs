using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreatePrimaryKeyCommand : SqlPrimaryKeyCommand, ICreatePrimaryKeyCommand
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
            ScriptBuilder.Append(Table.GetSqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append($" {PrimarykeyName}");
            ScriptBuilder.Append(" PRIMARY KEY");
            ScriptBuilder.Append($"({PrimaryKey.PrimaryColumn.Name})");
        }
    }
}
