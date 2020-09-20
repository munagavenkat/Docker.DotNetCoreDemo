using RestSharp;
using RestSharp.Authenticators;

namespace DNCD.Common.Base.APIClient
{
    public static class APIUtility
    {
        public static APIResponse APICall(string baseUrl, string action, object body, string userName, string password)
        {
            RestClient client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);
            
            Method method = Method.POST;
            RestRequest request = new RestRequest(action, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharp.Serialization.Json.JsonSerializer()
            };

            if (body != null)
            {
                request.AddBody(body);
            }

            request.JsonSerializer.ContentType = "application/json; charset=utf-8";
            var response = client.Execute(request);
            
            return new APIResponse()
            {
                IsSuccessful = response.IsSuccessful,
                Result = response.Content,
                ErrorException = response.ErrorException
            };

        }
    }
}
