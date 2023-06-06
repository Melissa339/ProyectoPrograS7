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
        private readonly IDepartamentoServices _departamentoServices;

        public MesaController(IMesaServices mesaServices, IUsuarioServices usuarioServices, IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;
            _mesaServices = mesaServices;
            _usuarioServices = usuarioServices;
        }
        public IActionResult Index()
        {
            var encargados = _usuarioServices.GetAll();
            var mesas = _mesaServices.GetAll();
            var departamentos = _departamentoServices.GetAll();

            return View(new MesasViewModel { departamentos = departamentos, mesas = mesas, usuarios = encargados});
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
