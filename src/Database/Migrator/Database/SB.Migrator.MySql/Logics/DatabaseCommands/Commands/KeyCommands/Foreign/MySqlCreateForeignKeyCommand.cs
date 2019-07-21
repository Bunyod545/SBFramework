using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlCreateForeignKeyCommand : MySqlForeignKeyCommand, ICreateForeignKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateForeignKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.Append(Table.GetMySqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append("ADD CONSTRAINT");
            ScriptBuilder.Append($" {GetForeignKeyName()}");

            ScriptBuilder.Append(" FOREIGN KEY");
            ScriptBuilder.Append($" ({ForeignKey.Column.GetMySqlName()})");

            ScriptBuilder.Append(" REFERENCES");
            ScriptBuilder.Append($" {ForeignKey.ReferenceTable.GetMySqlName()}");
            ScriptBuilder.Append($"({ForeignKey.ReferenceColumn.GetMySqlName()});");
        }
    }
}
