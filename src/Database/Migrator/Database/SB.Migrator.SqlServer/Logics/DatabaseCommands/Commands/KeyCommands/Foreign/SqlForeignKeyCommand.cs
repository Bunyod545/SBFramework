using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SqlForeignKeyCommand : SqlKeyCommand, IForeignKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ForeignKeyInfo ForeignKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        public virtual void SetForeignKey(ForeignKeyInfo foreignKey)
        {
            ForeignKey = foreignKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetForeignKeyName()
        {
            return string.IsNullOrEmpty(ForeignKey.Name) ? 
                $"FK_{ForeignKey.Table.Name}_{ForeignKey.ReferenceTable.Name}" : 
                ForeignKey.Name;
        }
    }
}
