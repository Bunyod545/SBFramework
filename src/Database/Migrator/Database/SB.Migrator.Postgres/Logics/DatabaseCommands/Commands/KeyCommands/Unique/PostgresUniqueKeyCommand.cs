using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PostgresUniqueKeyCommand : PostgresKeyCommand, IUniqueKeyCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public UniqueKeyInfo UniqueKey { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo Table => UniqueKey?.Table;

        /// <summary>
        /// 
        /// </summary>
        public string UniqueName => UniqueKey?.Name;

        /// <summary>
        /// 
        /// </summary>
        public List<ColumnInfo> UniqueColumns => Table.Columns;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        public virtual void SetUniqueKey(UniqueKeyInfo uniqueKey)
        {
            UniqueKey = uniqueKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetUniqueName()
        {
            return string.IsNullOrEmpty(UniqueName) ? InternalUniqueName() : UniqueName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string InternalUniqueName()
        {
            return "UC_" + Table.Name + "_" + string.Join("_", UniqueKey.UniqueColumns.Select(s => s.Name));
        }
    }
}
