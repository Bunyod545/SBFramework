using System.Text;
using SB.Common.Extensions;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreateUniqueCommand : SqlUniqueKeyCommand, ICreateUniqueKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateUniqueKey;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder.AppendLine($"ALTER TABLE {Table.GetSqlName()}");
            ScriptBuilder.Append($"ADD CONSTRAINT {GetUniqueName()} UNIQUE (");

            foreach (var column in UniqueColumns)
            {
                ScriptBuilder.Append(column.GetSqlName());
                ScriptBuilder.AppendIf(UniqueColumns.IsNotLast(column), " ,");
            }

            ScriptBuilder.Append(");");
        }
    }
}
