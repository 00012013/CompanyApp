using CompanyManagementApp.Models;
using CompanyManagementApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDepartmentService departmentService;

        public HomeController(ILogger<HomeController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            departmentService.CreateFirstDepartments();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}