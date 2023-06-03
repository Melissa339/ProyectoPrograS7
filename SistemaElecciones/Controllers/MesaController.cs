using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class MesaController : Controller
    {
        private readonly IMesaServices _mesaServices;
        private readonly IUsuarioServices _usuarioServices;

        public MesaController(IMesaServices mesaServices, IUsuarioServices usuarioServices)
        {
            _mesaServices = mesaServices;
            _usuarioServices = usuarioServices;
        }
        public IActionResult Index()
        {
            return View("MesasInfo");
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
            return View("MesasInfo", mesas);
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
