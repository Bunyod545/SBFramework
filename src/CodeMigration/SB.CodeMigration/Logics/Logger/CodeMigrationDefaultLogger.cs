using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeMigrationDefaultLogger : ICodeMigrationLogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
