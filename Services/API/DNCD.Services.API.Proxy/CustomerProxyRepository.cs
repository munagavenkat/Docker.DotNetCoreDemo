using DNCD.Common.Base.APIClient;
using DNCD.Common.Base.AppSettings;
using DNCD.Services.API.Proxy.Domains;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DNCD.Services.API.Proxy
{
    public class CustomerProxyRepository : ICustomerProxyRepository
    {
        private readonly IAppSettings _appSettings;
        private readonly IAPIClient _apiClient;

        public CustomerProxyRepository(IAppSettings appSettings, IAPIClient apiClient)
        {
            _appSettings = appSettings;
            _apiClient = apiClient;

        }

        /// <summary>
        /// Gets the PNR reply raw.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="action">The action.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public List<CustomerDomain> GetCustomers()
        {
            var result = _apiClient.GetAPICall(_appSettings.CustomerServiceAPI.BaseUrl,
                                    _appSettings.CustomerServiceAPI.GetCustomers, 
                                    null, 
                                    _appSettings.CustomerServiceAPI.APIUserName, 
                                    _appSettings.CustomerServiceAPI.APIPassword);

            var response =  JsonConvert.DeserializeObject<List<CustomerDomain>>(result.Result);

            return response;
        }

        public CustomerDomain GetCustomerByID(int ID)
        {
            var action = string.Format(_appSettings.CustomerServiceAPI.GetCustomerByID, ID);
            var result = _apiClient.GetAPICall(_appSettings.CustomerServiceAPI.BaseUrl,
                                   action,
                                   null,
                                   _appSettings.CustomerServiceAPI.APIUserName,
                                   _appSettings.CustomerServiceAPI.APIPassword);

            var response = JsonConvert.DeserializeObject<CustomerDomain>(result.Result);

            return response;
        }
    }
}
