using System;
using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataColumnTypeInfo : ColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public MetadataCodeTablesManager CodeTablesManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="columnMetadata"></param>
        public MetadataColumnTypeInfo(MetadataCodeTablesManager manager, ColumnMetadata columnMetadata)
        {
            CodeTablesManager = manager;
            ClrType = columnMetadata.Property.PropertyType;
            Type = columnMetadata.Type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetColumnType()
        {
            if (!string.IsNullOrEmpty(Type))
                return Type;

            if (ClrType.IsHasAttribute<TableAttribute>())
                return CodeTablesManager.GetTableMetadata(ClrType)?.PrimaryKey?.PrimaryColumn?.Type?.GetColumnType(); 

            var databaseManager = CodeTablesManager.MigrateManager?.DatabaseTablesManager;
            return databaseManager?.ColumnTypeMappingSource.FindType(ClrType);
        }
    }
}
