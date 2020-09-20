using DNCD.Common.Base.APIClient;
using DNCD.Services.API.Proxy.Domains;
using System.Collections.Generic;

namespace DNCD.Services.API.Proxy
{
    public interface ICustomerProxyRepository
    {
        List<CustomerDomain> GetCustomers();
        CustomerDomain GetCustomerByID(int ID);
    }
}
