using Microsoft.AspNetCore.Mvc;

namespace SistemaElecciones.Controllers
{
    public class VotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
