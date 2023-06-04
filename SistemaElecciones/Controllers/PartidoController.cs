using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Models;
using SistemaElecciones.Services;

namespace SistemaElecciones.Controllers
{
    public class PartidoController : Controller
    {
        private readonly IPartidoServices _partidoService;

        public PartidoController(IPartidoServices partidoService)
        {
            _partidoService = partidoService;
        }

        public IActionResult Index()
        {
            var partidos = _partidoService.GetAll();
            return View(partidos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(Partido partido)
        {
            try
            {
                _partidoService.Add(partido);

            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}
