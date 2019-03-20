using System;
using System.Collections.Generic;
using System.Text;
using SB.Migrator.Metadata;
using SB.Migrator.Metadata.Test.Logics.Metadata.Helpers;

namespace MetadataSqlMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Holiday")]
    public class Holiday
    {
        /// <summary>
        /// 
        /// </summary>
        [Column, PrimaryKey]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public string DesignedName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column, ForeignKey]
        public MonthsOfYear MonthsOfYear { get; set; }
    }
}
