namespace SB.Common
{
    /// <summary>
    /// Response model
    /// </summary>
    /// <typeparam name="T">Response result type</typeparam>
    public class Response<T> : Response where T: ResponseResult
    {
        /// <summary>
        /// Response result
        /// </summary>
        public new T Result
        {
            get => (T) base.Result;
            set => base.Result = value;
        }

        /// <summary>
        /// Response model
        /// </summary>
        public Response()
        {
            
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        public Response(T result) : base(result)
        {

        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public Response(ResponseError error) : base(error)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Response result</param>
        /// <param name="error">Response error</param>
        public Response(T result, ResponseError error) : base(result, error)
        {
            
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        public static implicit operator Response<T>(T result)
        {
            return new Response<T>(result);
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public static implicit operator Response<T>(ResponseError error)
        {
            return new Response<T>(error);
        }
    }
}
