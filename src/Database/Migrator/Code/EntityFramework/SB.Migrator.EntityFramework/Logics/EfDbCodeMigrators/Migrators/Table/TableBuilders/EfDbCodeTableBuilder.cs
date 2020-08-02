using SB.Migrator.Logics.ServiceContainers;
using SB.Migrator.Models;
using SB.Migrator.Models.Column;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EfDbCodeTableBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IMigrateServicesContainer ServicesContainer;

        /// <summary>
        /// 
        /// </summary>
        public TableInfo TableInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicesContainer"></param>
        /// <param name="tableInfo"></param>
        public EfDbCodeTableBuilder(IMigrateServicesContainer servicesContainer, TableInfo tableInfo)
        {
            ServicesContainer = servicesContainer;
            TableInfo = tableInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public EfDbCodeTableColumnBuilder Column<T>(string name)
        {
            var column = new ColumnInfo();
            column.Type = new EFColumnTypeInfo(typeof(T), ServicesContainer);
            column.Name = name;
           
            TableInfo.Columns.Add(column);
            return new EfDbCodeTableColumnBuilder(this, column);
        }
    }
}
