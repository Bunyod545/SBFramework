using SB.RestClient.Models.Response;

namespace SBRestClientConsoleExample
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestService
    {
        []
        IRestResponse<string, string> SearchGoogle();
    }
}