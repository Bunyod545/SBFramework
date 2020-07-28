using SB.Migrator.Logics.Database;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EfDbCodeTableColumnBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ColumnInfo _column;

        /// <summary>
        /// 
        /// </summary>
        public EfDbCodeTableBuilder TableBuilder { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableBuilder"></param>
        /// <param name="column"></param>
        public EfDbCodeTableColumnBuilder(EfDbCodeTableBuilder tableBuilder, ColumnInfo column)
        {
            TableBuilder = tableBuilder;
            _column = column;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EfDbCodeTableColumnBuilder PrimaryKey()
        {
            var primaryKey = new PrimaryKeyInfo();
            primaryKey.PrimaryColumn = _column;
            primaryKey.Table = TableBuilder.TableInfo;

            _column.Identity = new Identity(1, 1);
            TableBuilder.TableInfo.PrimaryKey = primaryKey;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public EfDbCodeTableColumnBuilder DefaultValue(object defaultValue)
        {
            _column.DefaultValue = defaultValue;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public EfDbCodeTableColumnBuilder Description(string description)
        {
            _column.Description = description;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public EfDbCodeTableColumnBuilder ForeignKey(string table, string column, string schema = null)
        {
            var foreignKey = new ForeignKeyInfo();
            foreignKey.Column = _column;
            foreignKey.Table = TableBuilder.TableInfo;

            var databaseTablesManager = TableBuilder.ServicesContainer.GetService<IDatabaseTablesManager>();
            var referenceTable = new TableInfo();
            referenceTable.Name = table;
            referenceTable.Schema = schema ?? databaseTablesManager.DefaultSchema;
            
            var referenceColumn = new ColumnInfo();
            referenceColumn.Name = column;
            referenceColumn.Table = referenceTable;
            referenceTable.Columns.Add(referenceColumn);

            referenceTable.PrimaryKey = new PrimaryKeyInfo();
            referenceTable.PrimaryKey.PrimaryColumn = referenceColumn;
            referenceTable.PrimaryKey.Table = referenceTable;

            foreignKey.ReferenceTable = referenceTable;
            foreignKey.ReferenceColumn = referenceColumn;

            TableBuilder.TableInfo.ForeignKeys.Add(foreignKey);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EfDbCodeTableColumnBuilder IsNullable()
        {
            _column.IsAllowNull = true;
            return this;
        }
    }
}
