using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class CandidatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
