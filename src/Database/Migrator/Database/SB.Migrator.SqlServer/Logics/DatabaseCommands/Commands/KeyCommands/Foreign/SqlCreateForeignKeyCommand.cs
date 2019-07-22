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
            ScriptBuilder.Append(Table.GetSqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append($" {ForeignKeyName}");

            ScriptBuilder.Append(" FOREIGN KEY");
            ScriptBuilder.Append($" ({ForeignKey.Column.Name})");

            ScriptBuilder.Append(" REFERENCES");
            ScriptBuilder.Append(ForeignKey.ReferenceTable.GetSqlName());
            ScriptBuilder.Append($" ({ForeignKey.ReferenceColumn.Name})");
        }
    }
}
