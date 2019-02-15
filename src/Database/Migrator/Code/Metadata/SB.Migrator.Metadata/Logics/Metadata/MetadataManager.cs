using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions;
using SB.Migrator.Metadata.Logics.Metadata.Models;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<TableMetadata> _tables;

        /// <summary>
        /// 
        /// </summary>
        public MetadataManager()
        {
            _tables = new List<TableMetadata>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableMetadata> GetTables()
        {
            var tableTypes = MetadataTablesHelper.GetTableTypes();
            return tableTypes.Select(GetTable).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public TableMetadata GetTable(Type tableType)
        {
            var tableMetadata = _tables.FirstOrDefault(f => f.TableType == tableType);
            if (tableMetadata != null)
                return tableMetadata;

            var tableAttr = tableType.GetCustomAttribute<TableAttribute>();

            tableMetadata = new TableMetadata();
            tableMetadata.TableType = tableType;
            tableMetadata.Name = tableAttr?.Name ?? tableType.Name;
            tableMetadata.Schema = tableAttr?.Schema;
            tableMetadata.Columns = GetColumns(tableMetadata);
            tableMetadata.PrimaryKey = GetPrimaryKey(tableMetadata);
            tableMetadata.ForeignKeys = GetForeignKeys(tableMetadata);

            _tables.Add(tableMetadata);
            return tableMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        public List<ColumnMetadata> GetColumns(TableMetadata tableMetadata)
        {
            var props = tableMetadata.TableType.GetProperties();
            return props.Select(p => GetColumn(p, tableMetadata)).ToList(w => w != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        public ColumnMetadata GetColumn(PropertyInfo property, TableMetadata tableMetadata)
        {
            var propAttr = property.GetCustomAttribute<ColumnAttribute>();
            if (propAttr == null)
                return null;

            var columnMetadata = new ColumnMetadata();
            columnMetadata.Table = tableMetadata;
            columnMetadata.Property = property;
            columnMetadata.Name = propAttr.Name ?? property.Name;
            columnMetadata.Type = propAttr.Type;
            columnMetadata.IsAllowNull = ColumnIsAllowNull(propAttr, columnMetadata);
            columnMetadata.DefaultValue = propAttr.DefaultValue;

            return columnMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propAttr"></param>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        public bool ColumnIsAllowNull(ColumnAttribute propAttr, ColumnMetadata columnMetadata)
        {
            if (propAttr.IsAllowNull.HasValue && propAttr.IsAllowNull.Value)
                return true;

            var type = columnMetadata.Property.PropertyType;
            return type.IsClass || type.IsNullable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        public PrimaryKeyMetadata GetPrimaryKey(TableMetadata tableMetadata)
        {
            var column = tableMetadata.Columns.FirstOrDefault(f => f.Property.IsHasAttribute<PrimaryKeyAttribute>());
            if (column == null)
                return null;

            var attr = column.Property.GetCustomAttribute<PrimaryKeyAttribute>();
            var primaryKey = new PrimaryKeyMetadata();
            primaryKey.PrimaryColumn = column;
            primaryKey.Name = attr.Name;

            return primaryKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        public List<ForeignKeyMetadata> GetForeignKeys(TableMetadata tableMetadata)
        {
            var columns = tableMetadata.Columns.ToList(f => f.Property.IsHasAttribute<ForeignKeyAttribute>());
            return columns.Select(GetForeignKey).ToList(w => w != null);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        public ForeignKeyMetadata GetForeignKey(ColumnMetadata columnMetadata)
        {
            var attr = columnMetadata.Property.GetCustomAttribute<ForeignKeyAttribute>();
            if (attr == null)
                return null;

            var foreignKey = new ForeignKeyMetadata();
            foreignKey.Column = columnMetadata;
            foreignKey.Name = attr.Name;
            foreignKey.Table = columnMetadata.Table;
            foreignKey.ReferencedTable = attr.ReferencedTable ?? columnMetadata.Property.PropertyType;
            foreignKey.ReferencedColumn = attr.ReferenceColumn;

            return foreignKey;
        }
    }
}
