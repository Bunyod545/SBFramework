namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public enum CommandOrder
    {
        /// <summary>
        /// 
        /// </summary>
        BeforeActualization,

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
        TableValue,

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
        DropUniqueKey,

        /// <summary>
        /// 
        /// </summary>
        CreateUniqueKey,

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

        /// <summary>
        /// 
        /// </summary>
        AfterActualization,
    }
}
