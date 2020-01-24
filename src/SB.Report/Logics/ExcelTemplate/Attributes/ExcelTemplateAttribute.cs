using System;

namespace SB.Report.Logics.ExcelTemplate
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExcelTemplateAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateName"></param>
        public ExcelTemplateAttribute(string templateName)
        {
            TemplateName = templateName;
        }
    }
}
