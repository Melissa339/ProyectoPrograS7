using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IVotoServices
    {
        List<Voto> GetAll();
        Voto? Get(Guid id);
        void Add(Voto voto);
        void Update(Voto voto);
        void Delete(Guid id);
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

        public Voto? Get(Guid id)
        {
            return _dbContext.Votos.FirstOrDefault(x => x.IdVoto == id);
        }

        public void Add(Voto voto)
        {
            voto.IdVoto = Guid.NewGuid();
            voto.EstadoEliminado = false;
            voto.BeforeSaveChanges();
            _dbContext.Votos.Add(voto);
            _dbContext.SaveChanges();
        }

        public void Update(Voto voto)
        {
            var votoBD = Get(voto.IdVoto);
            if (votoBD is not null)
            {
                votoBD.IdCandidato = voto.IdCandidato;
                votoBD.IdMesa = voto.IdMesa;
                votoBD.DpiCiudadano = voto.DpiCiudadano;
                votoBD.BeforeSaveChanges();
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var voto = Get(id);
            if (voto is not null)
            {
                voto.EstadoEliminado = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
