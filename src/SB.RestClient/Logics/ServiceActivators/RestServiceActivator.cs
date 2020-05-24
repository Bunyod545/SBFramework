using SB.RestClient.Logics.ServiceActivators.Validators;

namespace SB.RestClient.Logics.ServiceActivators
{
    /// <summary>
    /// 
    /// </summary>
    public static class RestServiceActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootUrl"></param>
        /// <returns></returns>
        public static T For<T>(string rootUrl)
        {
            RestServiceActivateValidateManager.Validate<T>();
            return default;
        } 
    }
}
