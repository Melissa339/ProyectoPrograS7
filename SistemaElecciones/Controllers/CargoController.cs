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
                _mesaServices.DeleteMesa(id);
            }
            catch { }
            //var vMesas = _mesaServices.GetAll();
            //var vUsuarios = _usuarioServices.GetAll();
            //return View(new MesasViewModel { mesas = vMesas, usuarios = vUsuarios });
            List<Mesa> mesas = _mesaServices.GetAll();
            return View("Index", mesas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mesa Mesa)
        {
            try
            {
                _mesaServices.AddMesa(Mesa);
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
    }
}
