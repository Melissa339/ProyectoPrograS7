using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IDepartamentoServices
    {
        List<Departamento> GetAll();
        void Add(Departamento departamennnto);
        //void Delete(Guid id);
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

        public void Add(Departamento departamento)
        {
            departamento.IdDepartamento = Guid.NewGuid();
            _dbContext.Departamentos.Add(departamento);
            _dbContext.SaveChanges();
        }
    }
}
