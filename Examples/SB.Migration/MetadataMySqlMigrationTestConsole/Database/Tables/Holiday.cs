﻿using SB.Migrator.Metadata;

namespace MetadataMySqlMigrationTestConsole.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("holidays")]
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
        [Column]
        public string TestName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column, ForeignKey]
        public MonthsOfYear MonthsOfYear { get; set; }
    }
}
