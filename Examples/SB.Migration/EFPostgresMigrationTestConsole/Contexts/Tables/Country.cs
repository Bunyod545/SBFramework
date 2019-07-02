using System.ComponentModel.DataAnnotations;

namespace EFPostgresMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
