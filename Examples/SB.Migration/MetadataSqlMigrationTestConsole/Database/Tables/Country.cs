﻿using SB.Migrator.Metadata;

namespace MetadataSqlMigrationTestConsole.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Countrys")]
    public partial class Country 
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
    }
}