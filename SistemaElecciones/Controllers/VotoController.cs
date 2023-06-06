using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class VotoController : Controller
    {
        private readonly IVotoServices _votoService;
        private readonly ICandidatoServices _candidatoService;
        private readonly IMesaServices _mesaService;

        private readonly IDepartamentoServices _departamentoService;

        public VotoController(IVotoServices votoService, ICandidatoServices candidatoService, IMesaServices mesaService, IDepartamentoServices departamentoServices)
        {
            _votoService = votoService;
            _candidatoService = candidatoService;
            _mesaService = mesaService;

            _departamentoService = departamentoServices;
        }

        public IActionResult Index()
        {
            var votos = _votoService.GetAll();
            var candidatos = _candidatoService.GetAll();
            var mesas = _mesaService.GetAll();

            var departamentos = _departamentoService.GetAll();
            return View(new VotoViewModel { Candidatos = candidatos, Votos = votos, Departamentos = departamentos, Mesas = mesas});
        }

        [HttpGet]
        public IActionResult Create()
        {
            var votos = _votoService.GetAll();
            var candidatos = _candidatoService.GetAll();
            var mesas = _mesaService.GetAll();

            var departamentos = _departamentoService.GetAll();
            return PartialView("_Create", new VotoViewModel { Candidatos = candidatos, Votos = votos, Departamentos = departamentos, Mesas = mesas });
        }

        [HttpPost]
        public ActionResult Create(Voto voto)
        {
            try
            {
                _votoService.Add(voto);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid votoId)
        {
            var candidatos = _candidatoService.GetAll();
            var mesas = _mesaService.GetAll();
            var departamentos = _departamentoService.GetAll();
            var voto = _votoService.Get(votoId);

            return PartialView("_Edit", new VotoViewModel { Candidatos = candidatos, Departamentos = departamentos, Mesas = mesas, Voto = voto });
        }

        [HttpPost]
        public ActionResult Editar(Voto voto)
        {
            try
            {
                _votoService.Update(voto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                _votoService.Delete(id);
            }
            catch { }
            return RedirectToAction("Index");
        }
    }
}
