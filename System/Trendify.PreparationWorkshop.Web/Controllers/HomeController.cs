using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trendify.PreparationWorkshop.Web.Models;

namespace Trendify.PreparationWorkshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageSupliers()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Storage()
        {
            return View();
        }
        public IActionResult ManageOrder()
        {
            return View();
        }
        public IActionResult Workers()
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
