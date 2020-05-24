using System.Net.Http;

namespace SB.RestClient.Logics.ServiceRequests.HttpMethods
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpPutAttribute : HttpAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public HttpPutAttribute(string url = null) : base(url)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Put;
        }
    }
}
