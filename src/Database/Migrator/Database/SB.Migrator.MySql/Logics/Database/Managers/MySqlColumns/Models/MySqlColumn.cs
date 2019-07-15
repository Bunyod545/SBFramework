namespace SB.Migrator.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DataType { get; set; }

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
    }
}
