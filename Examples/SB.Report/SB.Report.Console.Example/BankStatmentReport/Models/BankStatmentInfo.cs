namespace SB.Report.Console.Example.BankStatmentReport.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BankStatmentInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public BankStatementHeader Header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BankStatementRow> Rows { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BankStatementFooter Footer { get; set; }
    }
}
