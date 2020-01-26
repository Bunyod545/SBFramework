using System;

namespace SB.Report.Logics.ExcelTemplate.Logics.Exporters.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TemplateReportPropertyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TemplateReportPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
