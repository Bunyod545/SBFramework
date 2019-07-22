namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface INamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        ITableNamingManager TableNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IColumnNamingManager ColumnNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IPrimaryKeyNamingManager PrimaryKeyNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IForeignKeyNamingManager ForeignKeyNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IUniqueKeyNamingManager UniqueKeyNamingManager { get; set; }
    }
}