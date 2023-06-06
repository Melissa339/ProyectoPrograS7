using Microsoft.EntityFrameworkCore;
using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IResultadoServices
    {
        List<Resultado> GetAll();
        List<ResultadoViewModel> resumen();

        List<ResultadoViewModel> resumen2(Guid idCargo);
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class ResultadoServices : IResultadoServices
    {
        private readonly EleccionesContext _dbContext;

        public ResultadoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<ResultadoViewModel> resumen()
        {
            List<ResultadoViewModel> listaResultado = (from resultados in _dbContext.Resultados
                                                       join candidatos in _dbContext.Candidatos on resultados.IdCandidato equals candidatos.IdCandidato
                                                       join cargos in _dbContext.Cargos on candidatos.IdCargo equals cargos.IdCargo
                                                       group new { resultados, candidatos, cargos } by new { candidatos.Nombre, cargos.Descripcion } into grupo
                                                       select new ResultadoViewModel
                                                       {
                                                           resultados = grupo.Select(g => g.resultados).ToList(),
                                                           candidatos = grupo.Select(g => g.candidatos).ToList(),
                                                           cargos = grupo.Select(g => g.cargos).ToList()
                                                       }).ToList();

            return listaResultado;
        }

        public List<ResultadoViewModel> resumen2(Guid idCargo)
        {
            // Lógica para obtener los resultados, candidatos y cargos según el idCargo
            List<ResultadoViewModel> listaResultado = (from resultados in _dbContext.Resultados
                                                       join candidatos in _dbContext.Candidatos on resultados.IdCandidato equals candidatos.IdCandidato
                                                       join cargos in _dbContext.Cargos on candidatos.IdCargo equals cargos.IdCargo
                                                       // Agrega una condición para filtrar por idCargo
                                                       where cargos.IdCargo == idCargo
                                                       group new { resultados, candidatos, cargos } by new { candidatos.Nombre, cargos.Descripcion } into grupo
                                                       select new ResultadoViewModel
                                                       {
                                                           resultados = grupo.Select(g => g.resultados).ToList(),
                                                           candidatos = grupo.Select(g => g.candidatos).ToList(),
                                                           cargos = grupo.Select(g => g.cargos).ToList()
                                                       }).ToList();

            return listaResultado;
        }



        public List<Resultado> GetAll()
        {
            return _dbContext.Resultados.ToList();
        }
    }
}
