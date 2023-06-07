using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class CargoController : Controller
    {
        private readonly IMesaServices _mesaServices;
        private readonly IUsuarioServices _usuarioServices;
        private readonly IDepartamentoServices _departamentoServices;
        private readonly ICargoServices _cargoServices;

        public CargoController(IMesaServices mesaServices, IUsuarioServices usuarioServices, IDepartamentoServices departamentoServices, ICargoServices cargoServices)
        {
            _departamentoServices = departamentoServices;
            _mesaServices = mesaServices;
            _usuarioServices = usuarioServices;
            _cargoServices = cargoServices;
        }
        public IActionResult Index()
        {
            var cargo = _cargoServices.GetAll();

            return View("Index", cargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                _cargoServices.DeleteCargo(id);
            }
            catch { }
            List<Cargo> mesa = _cargoServices.GetAll();
            return View("Index", mesa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cargo cargo)
        {
            try
            {
                _cargoServices.Add(cargo);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
