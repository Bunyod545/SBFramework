using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFColumnTypeInfo : ColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IProperty Property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        public EFColumnTypeInfo(IProperty property)
        {
            Property = property;
            Type = property.Relational()?.ColumnType;
            ClrType = property.ClrType;
        }
    }
}
