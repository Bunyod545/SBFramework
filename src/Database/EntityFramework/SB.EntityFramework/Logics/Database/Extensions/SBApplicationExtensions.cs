using SB.EntityFramework.Logics.Database;
using SBCommon.Logics.Application;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class SBApplicationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISBApplication UseEntityFramework(this ISBApplication app, string connectionString)
        {
            app.Database = new EFDatabase();
            app.Database.ConnectionString = connectionString;

            return app;
        }
    }
}
