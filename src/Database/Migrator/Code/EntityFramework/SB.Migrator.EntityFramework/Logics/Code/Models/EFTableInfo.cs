using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.Models;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFTableInfo : TableInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEntityType Entity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbContext Context { get; set; }
    }
}
