using SB.Report.Console.Example.BankStatmentReport.Models;

namespace SB.Report.Console.Example.BankStatmentReport
{
    /// <summary>
    /// 
    /// </summary>
    public class BankStatementReportService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BankStatmentInfo GetBankStementReportInfo()
        {
            var info = new BankStatmentInfo();
            info.Header = new BankStatementHeader();
            info.Header.DocName = "Выписка банка";
            info.Header.DocNumber = 1;
            info.Header.DocDate = DateTime.Now;

            return info;
        }
    }
}
