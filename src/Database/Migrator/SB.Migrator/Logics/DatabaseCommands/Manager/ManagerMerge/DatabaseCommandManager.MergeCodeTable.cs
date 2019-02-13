using System;
using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

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
                return;
            }

            codeTable.Columns.ForEach(f => MergeCodeColumn(f, databaseTable.Columns));
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
            MergeCodeColumnIdentity(codeColumn, databaseColumn);
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
            if(string.Equals(codeColumn.Type?.GetColumnType(), databaseColumn.Type?.GetColumnType(), StringComparison.CurrentCultureIgnoreCase))
                return;

            AlterColumn(codeColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeColumn"></param>
        /// <param name="databaseColumn"></param>
        protected virtual void MergeCodeColumnIdentity(ColumnInfo codeColumn, ColumnInfo databaseColumn)
        {

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

            AlterColumn(codeColumn);
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
                CreateColumnDefaultValue(codeColumn);
                return;
            }

            DropColumnDefaultValue(codeColumn);
            CreateColumnDefaultValue(codeColumn);
        }
    }
}
