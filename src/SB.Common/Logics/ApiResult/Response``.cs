namespace SB.Common
{
    /// <summary>
    /// Response model
    /// </summary>
    /// <typeparam name="TResult">Response result type</typeparam>
    /// <typeparam name="TError">Response error type</typeparam>
    public class Response<TResult, TError> : Response<TResult>
        where TResult : ResponseResult
        where TError: ResponseError
    {
        /// <summary>
        /// Response error
        /// </summary>
        public new TError Error
        {
            get => (TError)base.Error;
            set => base.Error = value;
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
        public Response(TResult result) : base(result)
        {
            
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public Response(TError error) : base(error) 
        {
            
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        /// <param name="error">Response error</param>
        public Response(TResult result, TError error) : base(result, error)
        {

        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="result">Response result</param>
        public static implicit operator Response<TResult, TError>(TResult result)
        {
            return new Response<TResult, TError>(result);
        }

        /// <summary>
        /// Response model
        /// </summary>
        /// <param name="error">Response error</param>
        public static implicit operator Response<TResult, TError>(TError error)
        {
            return new Response<TResult, TError>(error);
        }
    }
}
