using System;
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
    }
}
