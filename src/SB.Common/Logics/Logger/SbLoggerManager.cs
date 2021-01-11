using NLog;
using NLog.Config;
using NLog.Targets;
using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class SbLoggerManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            Console.WriteLine("Logger configure begin");
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("logFile");
            fileTarget.FileName = "messages.log";

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = config;
            Console.WriteLine("Logger configure end");
        }
    }
}
