namespace SB.Common.Logics.Queue.Models
{
    public class QueueWaitResult
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSucced { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLimitExpired { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public QueueWaitResult()
        {
            IsSucced = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static QueueWaitResult LimitExpired()
        {
            var res = new QueueWaitResult();
            res.IsLimitExpired = true;
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"IsSucced : {IsSucced}, IsLimitExpired : {IsLimitExpired}";
        }
    }
}
