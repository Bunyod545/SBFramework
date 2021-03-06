﻿using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresCreateColumnCommand : PostgresColumnCommand, ICreateColumnCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateColumn;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            SetAlterTable();
            ScriptBuilder.Append(" ADD");
            SetColumnInfo();

            ScriptBuilder.AppendLine();
            ScriptBuilder.AppendLine($"comment on column {Table.GetPgSqlName()}.{Column.GetPgSqlName()} is '{Column.Description}';");
        }
    }
}
