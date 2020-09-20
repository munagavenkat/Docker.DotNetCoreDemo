using DNCD.Services.Features.Student.Model;
using System.Collections.Generic;
using System.Linq;

namespace DNCD.Services.Features.Student
{
    public class CustomerService : ICustomerService
    {
        private List<CustomerModel> _customers;

        public CustomerService()
        {
            _customers = CustomerData();
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _customers;
        }

        public CustomerModel GetCustomer(int ID)
        {
            return _customers.FirstOrDefault(f => f.ID == ID);
        }

        private List<CustomerModel> CustomerData()
        {
            return new List<CustomerModel>(){
                new CustomerModel()
                {
                    ID = 1,
                    Name = "James",
                    Email = "James@outlook.com",
                    PhoneNumber = "0401214121",
                    Address = "U 8 5-7 Pridlle Street Westmead 2145"
                },
                new CustomerModel()
                {
                    ID = 2,
                    Name = "Bond",
                    Email = "Bond@outlook.com",
                    PhoneNumber = "0401211111",
                    Address = "U 8 5-7 Railway Prade Westmead 2145"
                },
                new CustomerModel()
                {
                    ID = 3,
                    Name = "Ashok",
                    Email = "Ashok@outlook.com",
                    PhoneNumber = "0401222211",
                    Address = "U 1 1-5 Railway Prade Auburn 2145"
                }
            };
           
        }
    }
}
