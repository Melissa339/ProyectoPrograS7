using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface ICandidatoServices
    {
        List<Candidato> GetAll();
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class CandidatoServices : ICandidatoServices
    {
        private readonly EleccionesContext _dbContext;

        public CandidatoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Candidato> GetAll()
        {
            return _dbContext.Candidatos.ToList();
        }
    }
}
