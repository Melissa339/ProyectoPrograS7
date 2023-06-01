using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICargoServices _cargoServices;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ICargoServices cargoServices, IMemoryCache memoryCache)
        {
            _cargoServices = cargoServices;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            List<Cargo> cargos = _cargoServices.GetAll();

            return View(cargos);
        }
    }
}
