namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class StringMessagePropertyBuilder : DefaulMessagePropertyBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public StringMessagePropertyBuilder(ObjectMessageBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanWork(object obj)
        {
            return obj is string;
        }
    }
}
