using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IPartidoServices
    {
        List<Partido> GetAll();
        void Add(Partido partido);
        //void Delete(Guid id);
    }
    public class PartidoServices : IPartidoServices
    {
        private readonly EleccionesContext _dbContext;

        public PartidoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Partido> GetAll()
        {
            return _dbContext.Partidos.ToList();
        }

        public void Add(Partido partido)
        {
            partido.IdPartido = Guid.NewGuid();
            _dbContext.Partidos.Add(partido);
            _dbContext.SaveChanges();
        }
    }
}
