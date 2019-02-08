using SBCommon.Logics.Application;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public static class SBTypesInitializersExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISBApplication UseEFSbTypesInitializer(this ISBApplication app, SBSystemContext context)
        {
            app.TypesInitializer = new EFSBTypesInitializers(context);
            return app;
        }
    }
}
