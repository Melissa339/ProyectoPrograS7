using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class MesaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
