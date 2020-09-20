using RestSharp;
using RestSharp.Authenticators;
using System;

namespace DNCD.Common.Base.APIClient
{
    public class APIClient : IAPIClient
    {
        private readonly IRestClient _restClient;

        public HttpBasicAuthenticator BasicAuthenticator { get; set; }

        public APIClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public APIResponse GetAPICall(string baseUrl, string action, object body, string userName, string password)
        {
            return APICall(Method.GET, baseUrl, action, body, userName, password);
        }

        public APIResponse PostAPICall(string baseUrl, string action, object body, string userName, string password)
        {
            return APICall(Method.POST, baseUrl, action, body, userName, password);
        }

        public APIResponse APICall(Method method, string baseUrl, string action, object body, string userName, string password)
        {
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

            _restClient.BaseUrl = new Uri(baseUrl);
            _restClient.Authenticator = new HttpBasicAuthenticator(userName, password);
            var response = _restClient.Execute(request);

            return new APIResponse()
            {
                IsSuccessful = response.IsSuccessful,
                Result = response.Content,
                ErrorException = response.ErrorException
            };
        }
    }
}
