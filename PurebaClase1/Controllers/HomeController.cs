using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models;
using PurebaClase1.Models.dbModels;
using PurebaClase1.ViewModel;
using System.Diagnostics;

namespace PurebaClase1.Controllers
{

    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {

        private readonly ProyectoBDContext _context;

        public HomeController(ProyectoBDContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var listaRopa = _context.Ropas.ToList();
            viewModel.Ropa = listaRopa;
            return View(viewModel);
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