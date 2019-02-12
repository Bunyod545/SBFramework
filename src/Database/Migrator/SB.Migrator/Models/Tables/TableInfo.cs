using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColumnInfo> Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PrimaryKeyInfo PrimaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ForeignKeyInfo> ForeignKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo()
        {
            Columns = new List<ColumnInfo>();
            ForeignKeys = new List<ForeignKeyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ColumnInfo GetColumn(string name)
        {
            return Columns.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Schema}].[{Name}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="table2"></param>
        /// <returns></returns>
        public static bool operator ==(TableInfo table1, TableInfo table2)
        {
            if (table1 == null || table2 == null)
                return false;

            return table1.Schema == table2.Schema &&
                   table1.Name == table2.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="tableInfo2"></param>
        /// <returns></returns>
        public static bool operator !=(TableInfo table1, TableInfo tableInfo2)
        {
            return !(table1 == tableInfo2);
        }
    }
}
