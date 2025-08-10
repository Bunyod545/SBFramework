using SB.Common.Logics.Constants.Logics.ConstantRepositories;
using SB.Common.Test.Logics.Constants.Models;

namespace SB.Common.Test.Logics.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantContext : DbConstantContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstantSet<string> OrgName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantSet<ConstantEmployee> Director { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantContext() : base(new MemoryConstantRepository())
        {

        }
    }
}
