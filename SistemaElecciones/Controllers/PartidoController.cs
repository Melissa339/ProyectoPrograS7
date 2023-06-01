using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class PartidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
