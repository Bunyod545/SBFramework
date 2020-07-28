using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SB.Migrator.Logics.Code;
using SB.Migrator.Logics.Database;
using SB.Migrator.Logics.ServiceContainers;
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
        private readonly IMigrateServicesContainer _servicesContainer;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnClrType"></param>
        /// <param name="servicesContainer"></param>
        public EFColumnTypeInfo(Type columnClrType, IMigrateServicesContainer servicesContainer)
        {
            _servicesContainer = servicesContainer;
            ClrType = columnClrType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetColumnType()
        {
            if (!string.IsNullOrEmpty(Type))
                return Type;

            var columnTypeMappingSource = _servicesContainer.GetService<IColumnTypeMappingSource>();
            return columnTypeMappingSource?.FindType(ClrType);
        }
    }
}
