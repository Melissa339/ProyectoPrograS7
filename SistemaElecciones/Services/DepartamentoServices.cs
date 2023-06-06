using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{

    public interface IDepartamentoServices
    {
        List<Departamento> GetAll();
        Departamento? Get(Guid id);
    }

    public class DepartamentoServices : IDepartamentoServices
    {
        private readonly EleccionesContext _dbContext;

        public DepartamentoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Departamento> GetAll()
        {
            return _dbContext.Departamentos.ToList();
        }

        public Departamento? Get(Guid id)
        {
            return _dbContext.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
        }
    }
}
