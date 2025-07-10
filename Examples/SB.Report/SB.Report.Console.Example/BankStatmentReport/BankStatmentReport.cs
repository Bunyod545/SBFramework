using SB.Report.Logics.ExcelTemplate;

namespace SB.Report.Console.Example.BankStatmentReport
{
    /// <summary>
    /// 
    /// </summary>
    [ExcelTemplate("BankStatmentReport.xlsx")]
    public class BankStatmentReport : ExcelTemplateReport
    {
        /// <summary>
        /// 
        /// </summary>
        private BankStatementReportService service;

        /// <summary>
        /// 
        /// </summary>
        public BankStatmentReport()
        {
            service = new BankStatementReportService();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Generate()
        {
            var info = service.GetBankStementReportInfo();
            ExportRow("header", info.Header);

            foreach (var row in info.Rows)
                ExportRow("row", row);

            ExportRow("footer", info.Header);
        }
    }
}
