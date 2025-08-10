using SB.Common.Logics.Metadata;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SBType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPrimitive {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPeriodic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Synonym { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConstantInfo()
        {
            
        }
    }
}