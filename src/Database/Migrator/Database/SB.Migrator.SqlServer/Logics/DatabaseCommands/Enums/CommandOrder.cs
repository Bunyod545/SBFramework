﻿namespace SB.Migrator.SqlServer.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public enum CommandOrder
    {
        /// <summary>
        /// 
        /// </summary>
        CreateTable,

        /// <summary>
        /// 
        /// </summary>
        DropColumn,

        /// <summary>
        /// 
        /// </summary>
        RenameTable,

        /// <summary>
        /// 
        /// </summary>
        CreateColumn,

        /// <summary>
        /// 
        /// </summary>
        AlterColumn,

        /// <summary>
        /// 
        /// </summary>
        RenameColumn,

        /// <summary>
        /// 
        /// </summary>
        DropColumnDefaultValue,

        /// <summary>
        /// 
        /// </summary>
        CreateColumnDefaultValue,

        /// <summary>
        /// 
        /// </summary>
        DropPrimaryKey,

        /// <summary>
        /// 
        /// </summary>
        CreatePrimaryKey,

        /// <summary>
        /// 
        /// </summary>
        DropForeignKey,

        /// <summary>
        /// 
        /// </summary>
        DropTable,

        /// <summary>
        /// 
        /// </summary>
        CreateForeignKey,
    }
}