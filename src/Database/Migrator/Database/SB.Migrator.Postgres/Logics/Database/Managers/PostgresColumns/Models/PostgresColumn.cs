namespace SB.Migrator.Postgres
{
    /// <summary>
    /// 
    /// </summary>
    public class PostgresColumn
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
        public int Position { get; set; }

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
    }
}
