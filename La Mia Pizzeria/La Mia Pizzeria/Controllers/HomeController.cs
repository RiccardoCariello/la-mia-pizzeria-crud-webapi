using La_Mia_Pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace La_Mia_Pizzeria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet] //Attributo inserito all'inizio.
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View("Contacts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}