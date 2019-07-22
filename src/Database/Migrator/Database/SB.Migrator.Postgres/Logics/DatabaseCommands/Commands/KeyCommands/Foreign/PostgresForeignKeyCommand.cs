using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresForeignKeyCommand : PostgresKeyCommand, IForeignKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ForeignKeyInfo ForeignKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table => ForeignKey?.Table;

        /// <summary>
        /// 
        /// </summary>
        public string ForeignKeyName => ForeignKey?.Name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        public virtual void SetForeignKey(ForeignKeyInfo foreignKey)
        {
            ForeignKey = foreignKey;
        }
    }
}
