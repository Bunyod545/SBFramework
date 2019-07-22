namespace SB.Migrator.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultNamingManager : INamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        public ITableNamingManager TableNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IColumnNamingManager ColumnNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IPrimaryKeyNamingManager PrimaryKeyNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IForeignKeyNamingManager ForeignKeyNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IUniqueKeyNamingManager UniqueKeyNamingManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DefaultNamingManager()
        {
            TableNamingManager = new DefaultTableNamingManager();
            ColumnNamingManager = new DefaultColumnNamingManager();
            PrimaryKeyNamingManager = new DefaultPrimaryKeyNamingManager();
            ForeignKeyNamingManager = new DefaultForeignKeyNamingManager();
            UniqueKeyNamingManager = new DefaultUniqueKeyNamingManager();
        }
    }
}
