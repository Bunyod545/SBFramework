namespace SB.Migrator.EntityFramework.Logics
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EfDbCodeMigration
    {
        /// <summary>
        /// 
        /// </summary>
        protected IEfDbCodeTableMigrator TableMigrator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        protected EfDbCodeTableBuilder CreateTable(string tableName, string schemaName = null)
        {
            return TableMigrator.CreateTable(tableName, schemaName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        protected void DropTable(string tableName, string schema = null)
        {
            TableMigrator?.DropTable(tableName, schema);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldTableName"></param>
        /// <param name="newTableName"></param>
        /// <param name="schema"></param>
        protected void RenameTable(string oldTableName, string newTableName, string schema = null)
        {
            TableMigrator?.RenameTable(oldTableName, newTableName, schema);
        }
    }
}
