using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICargoServices _cargoServices;
        private readonly IMesaServices _mesaServices;
        private readonly IMemoryCache _memoryCache;
        private readonly IUsuarioServices _usuarioServices;

        public HomeController(IMesaServices mesaServices,ICargoServices cargoServices, IMemoryCache memoryCache, IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string password, string user)
        {

            var existingUser = _usuarioServices.Authenticate(user, password);
            //Usuario existingUser = new() { Nombre = "Dev", Apellido = "Test"};
            //existingUser.IdUsuario = new Guid();
            if (existingUser is not null)
            {
                string clave = "UserData";
                string valor = JsonConvert.SerializeObject(existingUser);
                _memoryCache.Set(clave, valor);
                TempData["UsuarioNombre"] = $"{existingUser.Nombre}";
                return RedirectToAction("Inicio", "Home");
            }
            else
            {
                return Content("alert('El usuario no existe');", "application/javascript"); // se agrega return content solo para probar el metodo.
            }

            // context.HttpContext.Session.SetString($"UserData({country + "|" + session.TaxId})", JsonConvert.SerializeObject(securityUserData));

            //return View("/Pacientes/Pacientes");
        }

        [HttpGet]
        public IActionResult LogOut() {
            return RedirectToAction("Index");
        }
    }
}
