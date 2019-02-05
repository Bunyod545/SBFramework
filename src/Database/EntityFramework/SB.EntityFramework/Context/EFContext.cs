using Microsoft.EntityFrameworkCore;
using SBCommon.Logics.Application;

namespace SB.EntityFramework.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class EFContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISBDatabase SbDatabase { get; set; }
    }
}
