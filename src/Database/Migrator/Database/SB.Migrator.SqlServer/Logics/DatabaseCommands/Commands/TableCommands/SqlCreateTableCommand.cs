﻿using System.Text;
using SB.Common.Helpers;
using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.Models.Column;
using SB.Migrator.SqlServer.Logics.DatabaseCommands.Helpers;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreateTableCommand : SqlTableCommand, ICreateTableCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrders.CreateTable;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("CREATE TABLE ");
            ScriptBuilder.AppendFormat("[{0}].[{1}]", Table.Schema, Table.Name);
            ScriptBuilder.Append(Strings.LBracket);

            Table.Columns.ForEach(BuildColumn);
            ScriptBuilder.AppendLine();
            ScriptBuilder.Append(Strings.RBracket);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildColumn(ColumnInfo column)
        {
            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendFormat("[{0}] ", column.Name);
            ScriptBuilder.Append(column.Type.GetColumnType());

            BuildIdentity(column);
            BuildNullableInfo(column);
            BuildPrimary(column);

            ScriptBuilder.Append(Strings.Comma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildIdentity(ColumnInfo column)
        {
            if (column.Identity != null)
                ScriptBuilder.AppendFormat(" IDENTITY({0},{1})", column.Identity.Increment, column.Identity.Seed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildNullableInfo(ColumnInfo column)
        {
            if (!column.IsAllowNull)
                ScriptBuilder.Append(" NOT");

            ScriptBuilder.Append(" NULL");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void BuildPrimary(ColumnInfo column)
        {
            if (column.IsPrimary())
                ScriptBuilder.Append(" PRIMARY KEY");
        }
    }
}