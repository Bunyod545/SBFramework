using System;
using System.Collections.Generic;
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
    }
}
