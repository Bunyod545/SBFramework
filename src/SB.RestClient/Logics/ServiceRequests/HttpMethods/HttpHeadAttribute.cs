using System.Net.Http;

namespace SB.RestClient.Logics.ServiceRequests.HttpMethods
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHeadAttribute : HttpAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public HttpHeadAttribute(string url = null) : base(url)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Head;
        }
    }
}
