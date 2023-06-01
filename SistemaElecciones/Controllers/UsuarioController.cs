using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
