using Microsoft.AspNetCore.Mvc;
using NimapWebApp.Models;
using NimapWebApp.Repository;
using System.Diagnostics;

namespace NimapWebApp.Controllers
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
            NimapRepo objNimapRepo = new NimapRepo();
            
       //    var abc = objNimapRepo.DeleteEmployee(2);   
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