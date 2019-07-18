using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Metadata.Logics.Metadata.Models;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class TableMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Decription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type TableType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColumnMetadata> Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PrimaryKeyMetadata PrimaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ForeignKeyMetadata> ForeignKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TableValueMetadata> TableValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableMetadata()
        {
            Columns = new List<ColumnMetadata>();
            ForeignKeys = new List<ForeignKeyMetadata>();
            TableValues = new List<TableValueMetadata>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ColumnMetadata GetColumnMetadata(string name)
        {
            return Columns.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Schema}.{Name}]";
        }
    }
}
