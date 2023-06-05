using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
            _mesaServices = mesaServices;
            _cargoServices = cargoServices;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            List<Cargo> cargos = _cargoServices.GetAll();

            return View(cargos);
        }

        public IActionResult MesasInfo()
        {
            var vMesas = _mesaServices.GetAll();
            var vUsuarios = _usuarioServices.GetAll();
            //return View(new MesasViewModel { mesas = vMesas, usuarios = vUsuarios });
            List<Mesa> mesas = _mesaServices.GetAll();
            return View("MesasInfo", mesas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                _mesaServices.DeleteMesa(id);
            }
            catch { }
            var vMesas = _mesaServices.GetAll();
            var vUsuarios = _usuarioServices.GetAll();
            //return View(new MesasViewModel { mesas = vMesas, usuarios = vUsuarios });
            List<Mesa> mesas = _mesaServices.GetAll();
            return View("MesasInfo", mesas);
        }
    }
}
