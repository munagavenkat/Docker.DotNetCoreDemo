using DNCD.Services.Features.Student;
using DNCD.Services.Features.Student.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DNCD.Service.API.Controllers
{
    // api/Customer
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        //GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var items = _customerService.GetCustomers();

            return Ok(items);
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> GetCustomerByID(int id)
        {
            var item = _customerService.GetCustomer(id);

            return Ok(item);
        }   
    }
}
