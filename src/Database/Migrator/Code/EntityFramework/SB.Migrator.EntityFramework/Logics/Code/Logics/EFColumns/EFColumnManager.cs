using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Migrator.EntityFramework.Logics.Code.Logics.EFColumns
{
    /// <summary>
    /// 
    /// </summary>
    public static class EFColumnManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public static List<EFColumn> GetEfColumns(EFTableInfo tableInfo)
        {
            var props = tableInfo.ClrType.GetProperties();
            return props.Select(s => GetEfColumn(tableInfo, s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private static EFColumn GetEfColumn(EFTableInfo tableInfo, PropertyInfo propertyInfo)
        {
            var efColumn = new EFColumn();
            efColumn.Property = propertyInfo;
            efColumn.Table = tableInfo;


            return efColumn;
        }
    }
}
