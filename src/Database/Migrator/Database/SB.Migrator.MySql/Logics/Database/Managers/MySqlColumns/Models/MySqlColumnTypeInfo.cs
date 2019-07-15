using System.Collections.Generic;
using SB.Common.Helpers;
using SB.Migrator.Models.Tables.Columns;

namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlColumnTypeInfo : ColumnTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<string> _textTypesWithLength = new List<string>()
        {
            "char" , "nchar", "varchar",
            "nvarchar", "binary", "varbinary"
        };

        /// <summary>
        /// 
        /// </summary>
        private readonly List<string> _numberTypesWithLength = new List<string>()
        {
            "decimal" , "numeric"
        };

        /// <summary>
        /// 
        /// </summary>
        private readonly List<string> _dateTypesWithLength = new List<string>()
        {
            "datetime2" , "datetimeoffset", "datetimeoffset", "time"
        };

        /// <summary>
        /// 
        /// </summary>
        public uint? CharacterMaximumLenght { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint? CharacterOctetLenght { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint? NumericPrecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint? NumericPrecisionRadix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint? NumericScale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint? DateTimePrecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlColumn"></param>
        public MySqlColumnTypeInfo(MySqlColumn sqlColumn)
        {
            Type = sqlColumn.DataType;
            CharacterMaximumLenght = sqlColumn.CharacterMaximumLenght;
            CharacterOctetLenght = sqlColumn.CharacterOctetLenght;
            NumericPrecision = sqlColumn.NumericPrecision;
            NumericPrecisionRadix = sqlColumn.NumericPrecisionRadix;
            NumericScale = sqlColumn.NumericScale;
            DateTimePrecision = sqlColumn.DateTimePrecision;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetColumnType()
        {
            if (_textTypesWithLength.Contains(Type))
                return GetTextWithLength();

            if (_numberTypesWithLength.Contains(Type))
                return GetNumberWithLength();

            if (_dateTypesWithLength.Contains(Type))
                return GetDateWithLength();

            return base.GetColumnType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetTextWithLength()
        {
            if (CharacterMaximumLenght == null)
                return Type;

            return GetTypeWithLength(CharacterMaximumLenght.GetValueOrDefault());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetDateWithLength()
        {
            if (DateTimePrecision == null)
                return Type;

            return GetTypeWithLength(DateTimePrecision.GetValueOrDefault());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetTypeWithLength(uint lenght)
        {
            var lenghtText = lenght == -1 ? "max" : lenght.ToString(); 
            return Type + Strings.LBracket + lenghtText + Strings.RBracket;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetNumberWithLength()
        {
            return Type + Strings.LBracket + NumericPrecision + Strings.Comma + NumericScale + Strings.RBracket;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetColumnType();
        }
    }
}
