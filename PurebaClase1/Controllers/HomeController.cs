using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Catalogo()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Acercadenosotros()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Soporte()
        {
            return View();
        }

        [Authorize]
        public IActionResult MiCuenta()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Ticketadmin()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Pantalladmin()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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