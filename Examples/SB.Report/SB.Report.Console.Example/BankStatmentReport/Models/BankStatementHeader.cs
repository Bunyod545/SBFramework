using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Report.Console.Example.BankStatmentReport.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BankStatementHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string DocName { get; set; } = "Test doc";

        /// <summary>
        /// 
        /// </summary>
        public DateTime DocDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public int DocNumber { get; set; } = 5;
    }
}
