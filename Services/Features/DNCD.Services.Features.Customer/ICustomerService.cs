using DNCD.Services.Features.Student.Model;
using System.Collections.Generic;

namespace DNCD.Services.Features.Student
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomer(int ID);
    }
}
