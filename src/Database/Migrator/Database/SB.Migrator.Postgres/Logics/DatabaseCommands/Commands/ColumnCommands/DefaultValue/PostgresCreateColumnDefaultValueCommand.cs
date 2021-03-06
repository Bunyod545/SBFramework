﻿using System.Text;
using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresCreateColumnDefaultValueCommand : PostgresColumnDefaultValueCommand, ICreateColumnDefaultValueCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Order => (int)CommandOrder.CreateColumnDefaultValue;

        /// <summary>
        /// 
        /// </summary>
        protected override void InternalBuildCommandText()
        {
            ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("ALTER TABLE ");
            ScriptBuilder.AppendFormat(Table.GetPgSqlName());

            ScriptBuilder.Append(" ADD CONSTRAINT");
            ScriptBuilder.Append(GetConstraintName());

            ScriptBuilder.Append(" DEFAULT");
            ScriptBuilder.Append($" ({Column.DefaultValue})");

            ScriptBuilder.Append(" FOR ");
            ScriptBuilder.Append(Column.GetPgSqlName());
        }
    }
}
