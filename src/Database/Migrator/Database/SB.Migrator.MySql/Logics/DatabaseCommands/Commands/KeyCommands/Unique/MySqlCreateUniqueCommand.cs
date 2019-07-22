using System.Linq;
using System.Text;
using SB.Common.Extensions;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlCreateUniqueCommand : MySqlUniqueKeyCommand, ICreateUniqueKeyCommand
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
            ScriptBuilder.Append($"ALTER TABLE {Table.GetMySqlName()} ADD CONSTRAINT {UniqueName} UNIQUE({column.GetMySqlName()});");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void BuildMultipleColumnUnique()
        {
            ScriptBuilder.AppendLine($"ALTER TABLE {Table.GetMySqlName()}");
            ScriptBuilder.Append($"ADD CONSTRAINT {UniqueName} UNIQUE (");

            foreach (var column in UniqueColumns)
            {
                ScriptBuilder.Append(column.GetMySqlName());
                ScriptBuilder.AppendIf(UniqueColumns.IsNotLast(column), " ,");
            }

            ScriptBuilder.Append(");");
        }
    }
}
