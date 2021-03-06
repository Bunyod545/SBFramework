﻿using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColumnInfo> Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UniqueKeyInfo> UniqueKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TableValueInfo> TableValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PrimaryKeyInfo PrimaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ForeignKeyInfo> ForeignKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo()
        {
            Columns = new List<ColumnInfo>();
            TableValues = new List<TableValueInfo>();
            ForeignKeys = new List<ForeignKeyInfo>();
            UniqueKeys = new List<UniqueKeyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ColumnInfo GetColumn(string name)
        {
            return Columns.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Schema}].[{Name}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEqual(TableInfo table)
        {
            if (table == null)
                return false;

            return table.Schema == Schema && table.Name == Name;
        }
    }
}
