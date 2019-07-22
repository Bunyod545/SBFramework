using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresPrimaryKeyCommand : PostgresKeyCommand, IPrimaryKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public PrimaryKeyInfo PrimaryKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table => PrimaryKey?.Table;

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryKeyName => PrimaryKey?.Name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        public virtual void SetPrimaryKey(PrimaryKeyInfo primaryKey)
        {
            PrimaryKey = primaryKey;
        }
    }
}
