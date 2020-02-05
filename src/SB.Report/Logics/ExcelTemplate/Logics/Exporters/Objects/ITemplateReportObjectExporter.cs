namespace SB.Report.Logics.ExcelTemplate.Logics.ObjectExporters
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITemplateReportObjectExporter : ITemplateReportExporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportInfo"></param>
        void Export<T>(T reportInfo) where T : class;
    }
}