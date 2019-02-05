using System;
using System.Diagnostics;
using System.Text;

namespace SBCommon.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            var message = new StringBuilder();
            message.Append("Message : ");
            message.Append(ex.Message);

            var innerException = ex.InnerException;
            while (innerException != null)
            {
                message.AppendLine("Inner Message : ");
                message.Append(innerException.Message);
                innerException = innerException.InnerException;
            }

            Trace.TraceError("Date : {0:dd.MM.yyyy HH:mm} Message {1}. {2}StackTrace: {3}",
                DateTime.Now,
                message,
                Environment.NewLine,
                ex.StackTrace);
        }
    }
}
