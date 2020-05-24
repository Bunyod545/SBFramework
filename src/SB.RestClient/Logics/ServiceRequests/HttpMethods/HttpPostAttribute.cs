using System.Net.Http;

namespace SB.RestClient.Logics.ServiceRequests.HttpMethods
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpPostAttribute : HttpAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public HttpPostAttribute(string url = null) : base(url)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
