using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IVotoServices
    {
        List<Voto> GetAll();
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class VotoServices : IVotoServices
    {
        private readonly EleccionesContext _dbContext;

        public VotoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Voto> GetAll()
        {
            return _dbContext.Votos.ToList();
        }
    }
}
