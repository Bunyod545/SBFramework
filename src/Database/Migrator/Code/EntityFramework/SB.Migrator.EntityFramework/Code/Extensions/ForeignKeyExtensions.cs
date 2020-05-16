using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class ForeignKeyExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        /// <returns></returns>
        public static string GetColumnName(this IForeignKey foreignKey)
        {
            return foreignKey.Properties.FirstOrDefault()?.Relational()?.ColumnName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        /// <returns></returns>
        public static string GetReferenceColumnName(this IForeignKey foreignKey)
        {
            return foreignKey.PrincipalKey?.Properties?.FirstOrDefault()?.Relational().ColumnName;
        }
    }
}
