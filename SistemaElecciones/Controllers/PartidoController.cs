using Microsoft.AspNetCore.Mvc;
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
    }
}
