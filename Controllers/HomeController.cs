using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppUsuarios.Models;

namespace WebAppUsuarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AccesoDatos _acceso;
        public HomeController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }

        [HttpPost]
        public IActionResult Submit(Usuarios modelo)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",modelo);
            }
            try
            {
                _acceso.AgregarUsuario(modelo);
                TempData["SuccessMessage"] = "Tu usuario se guardo con exito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Tu usuario no se guardo.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
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
