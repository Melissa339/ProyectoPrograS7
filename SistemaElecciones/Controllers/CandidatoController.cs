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
    }
}
