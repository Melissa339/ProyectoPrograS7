using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IPartidoServices
    {
        List<Partido> GetAll();
        Partido? Get(Guid id);
        void Add(Partido partido);
        void Update(Partido partido);
        void Delete(Guid id);
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

        public Partido? Get(Guid id)
        {
            return _dbContext.Partidos.FirstOrDefault(x => x.IdPartido == id);
        }

        public void Add(Partido partido)
        {
            partido.IdPartido = Guid.NewGuid();
            _dbContext.Partidos.Add(partido);
            _dbContext.SaveChanges();
        }

        public void Update(Partido partido)
        {
            var partidoBD = Get(partido.IdPartido);
            if (partidoBD is not null)
            {
                partidoBD.Nombre = partido.Nombre;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var partido = Get(id);
            if (partido is not null)
            {
                //partido.EstadoEliminado = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
