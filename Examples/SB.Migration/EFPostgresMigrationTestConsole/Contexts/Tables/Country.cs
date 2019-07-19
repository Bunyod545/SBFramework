using System.ComponentModel.DataAnnotations;

namespace EFPostgresMigrationTestConsole.Contexts.Tables
{
    /// <summary>
    /// Country info
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [MaxLength(500)]
        public string Name { get; set; }

        /// <summary>
        /// Country disegned name
        /// </summary>
        public string DesignedName { get; set; }
    }
}
