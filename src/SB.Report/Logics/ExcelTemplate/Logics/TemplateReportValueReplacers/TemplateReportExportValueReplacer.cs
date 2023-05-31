using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using SB.Common.Extensions;
using SB.Common.Helpers;
using SB.Report.Logics.ExcelTemplate.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Image = System.Drawing.Image;
using Match = System.Text.RegularExpressions.Match;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateReportExportValueReplacer : ITemplateReportExportValueReplacer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="values"></param>
        public void Replace(ExcelRange range, Dictionary<string, object> values)
        {
            var cells = range.ToList();
            cells.ForEach(f => ReplaceCell(f, values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="values"></param>
        private void ReplaceCell(ExcelRangeBase cell, Dictionary<string, object> values)
        {
            if (IsCannotRepace(cell))
                return;

            var replaceTemplates = GetReplaceTemplates(cell).ToList();
            replaceTemplates.ForEach(f => ReplaceTemplate(cell, f, values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private IEnumerable<string> GetReplaceTemplates(ExcelRangeBase cell)
        {
            const string pattern = @"(?<=\{).*?(?=\})";
            var matches = Regex.Matches(cell.Text, pattern);

            return matches.Cast<Match>().Select(s => s.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool IsCannotRepace(ExcelRangeBase cell)
        {
            return cell.Value == null ||
                   cell.Value.IsNotTypeOf<string>() ||
                   cell.Text.IsNotContains(Strings.LFigureBracket) ||
                   cell.Text.IsNotContains(Strings.RFigureBracket);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="replaceValue"></param>
        /// <param name="values"></param>
        private void ReplaceTemplate(ExcelRangeBase cell,
            string replaceValue, Dictionary<string, object> values)
        {
            if (!values.TryGetValue(replaceValue, out var value))
                return;

            var replaceText = Strings.LFigureBracket + replaceValue + Strings.RFigureBracket;
            if (value is Image img)
            {
                var row = cell.Start.Row;
                var column = cell.Start.Column;

                var rowOffset = row - 1;
                var columnOffset = column - 1;
                
                cell.Worksheet.Row(row).Height = img.Height;
                cell.Worksheet.Column(column).Width = img.Width / 6;
                cell.Value = cell.Text.Replace(replaceText, string.Empty);

                var pic = cell.Worksheet.Drawings.AddPicture(string.Empty, img);
                pic.SetPosition(rowOffset, 15, columnOffset, 10);
                return;
            }

            if (replaceText == cell.Text)
            {
                cell.Value = value;
                return;
            }

            cell.Value = cell.Text.Replace(replaceText, value?.ToString() ?? string.Empty);
        }
    }
}
