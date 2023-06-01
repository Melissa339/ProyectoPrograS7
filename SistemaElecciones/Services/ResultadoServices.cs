using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IResultadoServices
    {
        List<Resultado> GetAll();
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

        public List<Resultado> GetAll()
        {
            return _dbContext.Resultados.ToList();
        }
    }
}
