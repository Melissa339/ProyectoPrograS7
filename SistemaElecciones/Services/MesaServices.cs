using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IMesaServices
    {
        List<Mesa> GetAll();
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class MesaServices : IMesaServices
    {
        private readonly EleccionesContext _dbContext;

        public MesaServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Mesa> GetAll()
        {
            return _dbContext.Mesas.ToList();
        }
    }
}
