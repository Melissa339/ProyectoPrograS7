using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoServices _candidatoService;
        private readonly IPartidoServices _partidoService;
        private readonly ICargoServices _cargoService;

        public CandidatoController(ICandidatoServices candidatoService, IPartidoServices partidoService, ICargoServices cargoServices)
        {
            _candidatoService = candidatoService;
            _partidoService = partidoService;
            _cargoService = cargoServices;
        }

        public IActionResult Index()
        {
            var candidatos = _candidatoService.GetAll();
            var partidos = _partidoService.GetAll();
            var cargos = _cargoService.GetAll();

            return View(new CandidatoViewModel{ Candidatos = candidatos, Partidos = partidos, Cargos = cargos});
        }

        [HttpGet]
        public IActionResult Create()
        {
            var candidatos = _candidatoService.GetAll();
            var partidos = _partidoService.GetAll();
            var cargos = _cargoService.GetAll();

            return PartialView("_Create", new CandidatoViewModel { Candidatos = candidatos, Partidos = partidos, Cargos = cargos });
        }

        [HttpPost]
        public ActionResult Create(Candidato candidato)
        {
            try
            {
                _candidatoService.Add(candidato);

            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid candidatoId)
        {
            var partidos = _partidoService.GetAll();
            var cargos = _cargoService.GetAll();
            var candidato = _candidatoService.Get(candidatoId);

            return PartialView("_Edit", new CandidatoViewModel { Candidato = candidato, Partidos = partidos, Cargos = cargos });
        }

        [HttpPost]
        public ActionResult Editar(Candidato candidato)
        {
            try
            {
                _candidatoService.Update(candidato);
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
                _candidatoService.Delete(id);
            }
            catch { }
            return RedirectToAction("Index");
        }
    }
}
