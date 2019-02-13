using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlColumnTypeInfo : ColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int? CharacterMaximumLenght { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? CharacterOctetLenght { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NumericPrecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NumericPrecisionRadix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NumericScale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DateTimePrecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlColumn"></param>
        public SqlColumnTypeInfo(SqlColumn sqlColumn)
        {
            Type = sqlColumn.DataType;
            CharacterMaximumLenght = sqlColumn.CharacterMaximumLenght;
            CharacterOctetLenght = sqlColumn.CharacterOctetLenght;
            NumericPrecision = sqlColumn.NumericPrecision;
            NumericPrecisionRadix = sqlColumn.NumericPrecisionRadix;
            NumericScale = sqlColumn.NumericScale;
            DateTimePrecision = sqlColumn.DateTimePrecision;
        }
    }
}
