using DNCD.Project.Portal.Models;
using DNCD.Services.API.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DNCD.Project.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerProxyRepository _customerProxyRepository;

        public HomeController(ILogger<HomeController> logger, ICustomerProxyRepository customerProxyRepository)
        {
            _logger = logger;
            _customerProxyRepository = customerProxyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Customers()
        {
            var list = _customerProxyRepository.GetCustomers();
            return View(list);
        }

        public IActionResult Customer(int id)
        {
            var item = _customerProxyRepository.GetCustomerByID(id); ;
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
