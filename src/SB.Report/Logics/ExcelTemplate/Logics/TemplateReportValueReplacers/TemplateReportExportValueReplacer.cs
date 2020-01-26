using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using SB.Common.Extensions;
using SB.Common.Helpers;

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
        private void ReplaceTemplate(ExcelRangeBase cell, string replaceValue, Dictionary<string, object> values)
        {
            if (!values.TryGetValue(replaceValue, out var value))
                return;

            var replaceText = Strings.LFigureBracket + replaceValue + Strings.RFigureBracket;
            if (replaceText == cell.Text)
            {
                cell.Value = value;
                return;
            }

            cell.Value = cell.Text.Replace(replaceText, value?.ToString() ?? string.Empty);
        }
    }
}
