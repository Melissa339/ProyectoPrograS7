using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Models;
using Microsoft.Extensions.Caching.Memory;
using SistemaElecciones.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace SistemaElecciones.Controllers
{

    public class ResultadoController : Controller
    {
        private readonly IResultadoServices _resultadosServices;
        private readonly ICandidatoServices _candidatoServices;
        private readonly ICargoServices _cargoServices;
        public ResultadoController(IResultadoServices resultadoServices, ICandidatoServices candidatoServices, ICargoServices cargoServices)
        {
            _resultadosServices = resultadoServices;
            _candidatoServices = candidatoServices;
            _cargoServices = cargoServices;
        }
        public IActionResult Index()
        {
            var resultados = _resultadosServices.GetAll();
            var candidatos = _candidatoServices.GetAll();
            var cargos = _cargoServices.GetAll();

            return View(new ResultadoViewModel { resultados = resultados, candidatos = candidatos, cargos = cargos });
        }


        public IActionResult resumenResultados()
        {

            var resultados = _resultadosServices.GetAll();
            var candidatos = _candidatoServices.GetAll();
            var cargos = _cargoServices.GetAll();

            return View(new ResultadoViewModel {resultados = resultados, candidatos = candidatos, cargos = cargos});
            //var resumenLista = _resultadosServices.resumen();
            //var resumennJson = JsonConvert.SerializeObject(resumenLista);

            //if (resumenLista.IsNullOrEmpty())
            //{
            //    return Json(JsonConvert.SerializeObject(resumenLista));
            //    //return StatusCode(StatusCodes.Status200OK, resumenLista);
            //}de
            
            
           // return View("Index");
        }

        [HttpGet]
        public IActionResult ObtenerDatosGrafica(Guid idCargo)
        {
            var listaResultado = _resultadosServices.resumen3(idCargo);

            // Obtener los nombres de los candidatos y los votos de los resultados
            var nombresCandidatos = listaResultado.SelectMany(r => r.candidatos).Select(c => c.Nombre).ToList();
            var votos = listaResultado.SelectMany(r => r.candidatos).Select(r => r.CantidadVotos).ToList();

            // Crear un objeto anónimo con los datos filtrados
            var datosGrafica = new { nombresCandidatos, votos };

            return Json(datosGrafica);
        }


    }
}
