using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreateForeignKeyCommand : SqlForeignKeyCommand, ICreateForeignKeyCommand
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
            ScriptBuilder.Append($"[{ForeignKey.Table.Schema}].[{ForeignKey.Table.Name}]");

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append($" {GetForeignKeyName()}");

            ScriptBuilder.Append(" FOREIGN KEY");
            ScriptBuilder.Append($" ({ForeignKey.Column.Name})");

            ScriptBuilder.Append(" REFERENCES");
            ScriptBuilder.Append($"[{ForeignKey.ReferenceTable.Schema}].[{ForeignKey.ReferenceTable.Name}]");
            ScriptBuilder.Append($" ({ForeignKey.ReferenceColumn.Name})");
        }
    }
}
