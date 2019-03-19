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
    public static class MetadataEnumTablesHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public static TableMetadata GetTableMetadata(Type tableType)
        {
            if (tableType == null || !tableType.IsEnum)
                return null;

            var tableAttr = tableType.GetCustomAttribute<TableAttribute>();

            var tableMetadata = new TableMetadata();
            tableMetadata.TableType = tableType;
            tableMetadata.Name = tableAttr?.Name ?? tableType.Name;
            tableMetadata.Schema = tableAttr?.Schema;
            tableMetadata.Columns = GetColumns(tableMetadata);
            tableMetadata.PrimaryKey = GetPrimaryKey(tableMetadata);
            tableMetadata.TableValues = GetTableValues(tableMetadata);

            return tableMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        private static List<ColumnMetadata> GetColumns(TableMetadata tableMetadata)
        {
            var columns = new List<ColumnMetadata>();

            var idColumn = new ColumnMetadata();
            idColumn.IsAllowNull = false;
            idColumn.Table = tableMetadata;
            idColumn.Name = nameof(EnumTableMetadata.Id);
            idColumn.Property = GetProperty(idColumn.Name);
            columns.Add(idColumn);

            var nameColumn = new ColumnMetadata();
            nameColumn.IsAllowNull = false;
            nameColumn.Table = tableMetadata;
            nameColumn.Name = nameof(EnumTableMetadata.Name);
            nameColumn.Property = GetProperty(nameColumn.Name);
            columns.Add(nameColumn);

            var synonymColumn = new ColumnMetadata();
            synonymColumn.IsAllowNull = true;
            synonymColumn.Table = tableMetadata;
            synonymColumn.Name = nameof(EnumTableMetadata.Synonym);
            synonymColumn.Property = GetProperty(synonymColumn.Name);
            columns.Add(synonymColumn);

            return columns;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static PropertyInfo GetProperty(string name)
        {
            var type = typeof(EnumTableMetadata);
            return type.GetProperty(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        private static PrimaryKeyMetadata GetPrimaryKey(TableMetadata tableMetadata)
        {
            var primaryKey = new PrimaryKeyMetadata();
            primaryKey.PrimaryColumn = tableMetadata.GetColumnMetadata(nameof(EnumTableMetadata.Id));
            primaryKey.Name = "PK_enum_" + tableMetadata.Name;

            return primaryKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<TableValueMetadata> GetTableValues(TableMetadata tableMetadata)
        {
            var result = new List<TableValueMetadata>();

            var enumType = tableMetadata.TableType;
            var values = Enum.GetValues(enumType);

            foreach (var value in values)
            {
                var valueMetadata = new TableValueMetadata();
                valueMetadata.Table = tableMetadata;
                valueMetadata.ValueMetadata = GetValueMetadata(value, tableMetadata).ToList();

                result.Add(valueMetadata);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static IEnumerable<TableValueItemMetadata> GetValueMetadata(object value, TableMetadata tableMetadata)
        {
            var idValue = new TableValueItemMetadata();
            idValue.Column = tableMetadata.GetColumnMetadata(nameof(EnumTableMetadata.Id));
            idValue.Value = (int)value;
            yield return idValue;

            var nameValue = new TableValueItemMetadata();
            nameValue.Column = tableMetadata.GetColumnMetadata(nameof(EnumTableMetadata.Name));
            nameValue.Value = value.ToSafeString();
            yield return nameValue;
        }
    }
}
