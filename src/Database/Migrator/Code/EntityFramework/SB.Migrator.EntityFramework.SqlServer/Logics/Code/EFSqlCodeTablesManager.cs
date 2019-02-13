namespace SB.Migrator.EntityFramework.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSqlCodeTablesManager : EFCodeTablesManager
    {
        /// <summary>
        /// 
        /// </summary>
        public EFSqlCodeTablesManager()
        {
           TypeInfoCreator = new EFSqlColumnTypeInfoCreator();       
        }
    }
}
