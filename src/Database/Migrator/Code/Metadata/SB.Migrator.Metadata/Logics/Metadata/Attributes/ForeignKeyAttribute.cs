﻿using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ReferencedTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReferenceColumn { get; set; }
    }
}
