using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
