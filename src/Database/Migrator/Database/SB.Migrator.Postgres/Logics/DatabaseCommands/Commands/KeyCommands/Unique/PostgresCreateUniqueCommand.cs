using System.Linq;
using System.Text;
using SB.Common.Extensions;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresCreateUniqueCommand : PostgresUniqueKeyCommand, ICreateUniqueKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.DropUniqueKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            if (UniqueColumns.Count == 1)
            {
                BuildSingleColumnUnique();
                return;
            }

            BuildMultipleColumnUnique();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void BuildSingleColumnUnique()
        {
            var column = UniqueKey.UniqueColumns.FirstOrDefault();
            ScriptBuilder.Append($"ALTER TABLE {Table.GetPgSqlName()} ADD CONSTRAINT {GetUniqueName()} UNIQUE({column.GetPgSqlName()});");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void BuildMultipleColumnUnique()
        {
            ScriptBuilder.AppendLine($"ALTER TABLE {Table.GetPgSqlName()}");
            ScriptBuilder.Append($"ADD CONSTRAINT {GetUniqueName()} UNIQUE (");

            foreach (var column in UniqueColumns)
            {
                ScriptBuilder.Append(column.GetPgSqlName());
                ScriptBuilder.AppendIf(UniqueColumns.IsNotLast(column), " ,");
            }

            ScriptBuilder.Append(");");
        }
    }
}
