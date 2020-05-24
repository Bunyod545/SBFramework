using System;
using System.Net.Http;

namespace SB.RestClient.Logics.ServiceRequests.HttpMethods
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        protected HttpAttribute(string url)
        {
            Url = url ?? string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract HttpMethod GetHttpMethod();
    }
}
