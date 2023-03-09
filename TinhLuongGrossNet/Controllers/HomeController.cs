using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TinhLuongGrossNet.Models;

namespace TinhLuongGrossNet.Controllers
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
        [HttpPost]
        public IActionResult Index(Luong request)
        {
            return View();
        }
        [HttpGet]
        public IActionResult LuongGross()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LuongGross(Luong request)
        {
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