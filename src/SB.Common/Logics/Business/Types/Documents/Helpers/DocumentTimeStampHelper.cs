using System;
using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Business.Types.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public static class DocumentTimeStampHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static DateTime GetPeriodicDate(Document doc)
        {
            var docType = (SBDocumentType)SBType.GetType(doc);
            switch (docType.Periodicity)
            {
                case Periodicity.None:
                    return DateTimeNow.Now;

                case Periodicity.Day:
                    return doc.Date.BeginOfDay();

                case Periodicity.Month:
                    return doc.Date.StartOfMonth();

                case Periodicity.Quarter:
                    return doc.Date.GetQuarterBegin();

                case Periodicity.Year:
                    return doc.Date.StartOfYear();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
