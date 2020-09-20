namespace DNCD.Common.Base.APIClient
{
    public interface IAPIClient
    {
        APIResponse GetAPICall(string baseUrl, string action, object body, string userName, string password);
        APIResponse PostAPICall(string baseUrl, string action, object body, string userName, string password);
    }
}
