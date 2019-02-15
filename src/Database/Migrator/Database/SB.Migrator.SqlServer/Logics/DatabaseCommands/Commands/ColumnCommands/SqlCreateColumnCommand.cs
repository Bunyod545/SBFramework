﻿using SB.Migrator.Logics.DatabaseCommands;
using SB.Migrator.SqlServer.Logics.DatabaseCommands;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlCreateColumnCommand : SqlColumnCommand, ICreateColumnCommand
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
        }
    }
}
