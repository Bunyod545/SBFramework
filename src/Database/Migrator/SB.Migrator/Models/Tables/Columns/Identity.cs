namespace SB.Migrator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Increment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Seed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Identity()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="increment"></param>
        /// <param name="seed"></param>
        public Identity(int increment, int seed)
        {
            Increment = increment;
            Seed = seed;
        }
    }
}
