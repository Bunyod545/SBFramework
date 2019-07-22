using System.Collections.Generic;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MySqlUniqueKeyCommand : MySqlKeyCommand, IUniqueKeyCommand
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
        public List<ColumnInfo> UniqueColumns => UniqueKey.UniqueColumns;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        public virtual void SetUniqueKey(UniqueKeyInfo uniqueKey)
        {
            UniqueKey = uniqueKey;
        }
    }
}
