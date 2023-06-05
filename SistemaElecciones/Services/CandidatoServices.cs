using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface ICandidatoServices
    {
        List<Candidato> GetAll();
        void Add(Candidato candidato);
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

        public void Add(Candidato candidato)
        {
            candidato.IdCandidato = Guid.NewGuid();
            _dbContext.Candidatos.Add(candidato);
            _dbContext.SaveChanges();
        }
    }
}
