using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresCreateForeignKeyCommand : PostgresForeignKeyCommand, ICreateForeignKeyCommand
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
            ScriptBuilder.Append(Table.GetPgSqlName());

            ScriptBuilder.AppendLine();
            ScriptBuilder.Append("ADD CONSTRAINT");
            ScriptBuilder.Append($" {GetForeignKeyName()}");

            ScriptBuilder.Append(" FOREIGN KEY");
            ScriptBuilder.Append($" ({ForeignKey.Column.GetPgSqlName()})");

            ScriptBuilder.Append(" REFERENCES");
            ScriptBuilder.Append($" {ForeignKey.ReferenceTable.GetPgSqlName()}");
            ScriptBuilder.Append($" ({ForeignKey.ReferenceColumn.GetPgSqlName()})");
        }
    }
}
