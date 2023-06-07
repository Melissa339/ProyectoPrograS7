using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface ICandidatoServices
    {
        List<Candidato> GetAll();
        Candidato? Get(Guid id);
        void Add(Candidato candidato);
        void Update(Candidato candidato);
        void AddVoto(Guid id);
        void Delete(Guid id);
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

        public Candidato? Get(Guid id)
        {
            return _dbContext.Candidatos.FirstOrDefault(x => x.IdCandidato == id);
        }

        public void Add(Candidato candidato)
        {
            candidato.IdCandidato = Guid.NewGuid();
            candidato.EstadoEliminado = false;
            candidato.BeforeSaveChanges();
            _dbContext.Candidatos.Add(candidato);
            _dbContext.SaveChanges();
        }

        public void Update(Candidato candidato)
        {
            var candidatoBD = Get(candidato.IdCandidato);
            if (candidatoBD is not null)
            {
                candidatoBD.Nombre = candidato.Nombre;
                candidatoBD.Apellido = candidato.Apellido;
                candidatoBD.Dpi = candidato.Dpi;
                candidatoBD.IdCargo = candidato.IdCargo;
                candidatoBD.IdPartido = candidato.IdPartido;
                candidatoBD.FechaNacimiento = candidato.FechaNacimiento;
                candidatoBD.Genero = candidato.Genero;
                candidatoBD.Telefono = candidato.Telefono;
                candidatoBD.Correo= candidato.Correo;
                candidatoBD.Profesion= candidato.Profesion;
                candidatoBD.Antecedentes = candidato.Antecedentes;
                candidatoBD.BeforeSaveChanges();

                _dbContext.SaveChanges();
            }
        }

        public void AddVoto(Guid id)
        {
            var candidatoBD = Get(id);
            if (candidatoBD is not null)
            {
                if (candidatoBD.CantidadVotos == null)
                {
                    candidatoBD.CantidadVotos = 1;
                    candidatoBD.BeforeSaveChanges();
                    _dbContext.SaveChanges();
                }
                else
                {
                    candidatoBD.CantidadVotos += 1;
                    candidatoBD.BeforeSaveChanges();
                    _dbContext.SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            var candidato = Get(id);
            if (candidato is not null)
            {
                candidato.EstadoEliminado = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
