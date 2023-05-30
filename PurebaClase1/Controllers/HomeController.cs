using Microsoft.AspNetCore.Mvc;
using PurebaClase1.Models;
using System.Diagnostics;

namespace PurebaClase1.Controllers
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

        public IActionResult Catalogo()
        {
            return View();
        }

        public IActionResult Acercadenosotros()
        {
            return View();
        }

        public IActionResult Soporte()
        {
            return View();
        }

        public IActionResult MiCuenta()
        {
            return View();
        }

        public IActionResult Ticketadmin()
        {
            return View();
        }

        public IActionResult Pantalladmin()
        {
            return View();
        }

        public IActionResult Ropadmin()
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