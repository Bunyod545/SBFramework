using System;
using System.Collections.Generic;
using System.Linq;
using SB.Common.Extensions;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeTable"></param>
        /// <param name="databaseTables"></param>
        protected virtual void MergeCodeTable(TableInfo codeTable, List<TableInfo> databaseTables)
        {
            var databaseTable = databaseTables.FirstOrDefault(f => f.IsEqual(codeTable));
            if (databaseTable == null)
            {
                CreateTable(codeTable);
                codeTable.ForeignKeys.ForEach(CreateForeignKey);
                codeTable.UniqueKeys.ForEach(CreateUniqueKey);
                MergeTableValues(codeTable);
                return;
            }

            codeTable.ForeignKeys.ForEach(f => MergeCodeTableForeignKey(f, databaseTable.ForeignKeys));
            codeTable.Columns.ForEach(f => MergeCodeColumn(f, databaseTable.Columns));
            codeTable.UniqueKeys.ForEach(f => MergeTableUnique(f, databaseTable.UniqueKeys));
            MergeTableValues(codeTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeForeignKey"></param>
        /// <param name="databaseForeignKeys"></param>
        protected virtual void MergeCodeTableForeignKey(ForeignKeyInfo codeForeignKey, List<ForeignKeyInfo> databaseForeignKeys)
        {
            var databaseForeignKey = databaseForeignKeys.FirstOrDefault(f => f.IsEqual(codeForeignKey));
            if (databaseForeignKey == null)
                CreateForeignKey(codeForeignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumns"></param>
        protected virtual void MergeCodeColumn(ColumnInfo codeColumn, List<ColumnInfo> databaseColumns)
        {
            var databaseColumn = databaseColumns.FirstOrDefault(f => f.IsEqual(codeColumn));
            if (databaseColumn == null)
            {
                CreateColumn(codeColumn);
                return;
            }

            MergeCodeColumnName(codeColumn, databaseColumn);
            MergeCodeColumnType(codeColumn, databaseColumn);
            MergeCodeColumnIsAllowNull(codeColumn, databaseColumn);
            MergeCodeColumnDefaultValue(codeColumn, databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void MergeCodeColumnName(ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {
            if (codeColumn.IsMustRenameColumn(databaseColumn))
                RenameColumn(codeColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void MergeCodeColumnType(ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {
            if (string.Equals(codeColumn.Type?.GetColumnType(), databaseColumn.Type?.GetColumnType(), StringComparison.CurrentCultureIgnoreCase))
                return;

            AlterColumn(codeColumn, databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void MergeCodeColumnIsAllowNull(ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {
            if (codeColumn.IsAllowNull == databaseColumn.IsAllowNull)
                return;

            AlterColumn(codeColumn, databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void MergeCodeColumnDefaultValue(ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {
            if (codeColumn.DefaultValue == null && databaseColumn.DefaultValue == null)
                return;

            if (codeColumn.DefaultValue == databaseColumn.DefaultValue)
                return;

            if (codeColumn.DefaultValue == null)
            {
                DropColumnDefaultValue(codeColumn);
                return;
            }

            if (databaseColumn.DefaultValue == null)
            {
                CreateColumnDefaultValue(codeColumn, databaseColumn);
                return;
            }

            DropColumnDefaultValue(codeColumn);
            CreateColumnDefaultValue(codeColumn, databaseColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeTableInfo"></param>
        protected virtual void MergeTableValues(TableInfo codeTableInfo)
        {
            if (!codeTableInfo.TableValues.IsNullOrEmpty())
                SetTableValues(codeTableInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeUnique"></param>
        /// <param name="databaseUniques"></param>
        protected virtual void MergeTableUnique(UniqueKeyInfo codeUnique, List<UniqueKeyInfo> databaseUniques)
        {
            var databaseUnique = databaseUniques.FirstOrDefault(f => f.Name == codeUnique.Name);
            if (databaseUnique == null)
            {
                CreateUniqueKey(codeUnique);
                return;
            }

            if (databaseUnique.UniqueColumns.Count != codeUnique.UniqueColumns.Count)
            {
                DropUniqueKey(databaseUnique);
                CreateUniqueKey(codeUnique);
                return;
            }

            var dbColumns = databaseUnique.UniqueColumns;
            var codeColumns = codeUnique.UniqueColumns;

            var equalColumns = codeColumns.All(c => dbColumns.Any(db => db.IsEqual(c)));
            if (equalColumns)
                return;

            DropUniqueKey(databaseUnique);
            CreateUniqueKey(databaseUnique);
        }
    }
}
