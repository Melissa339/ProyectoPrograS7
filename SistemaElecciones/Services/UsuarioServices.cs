using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IUsuarioServices
    {
        List<Usuario> GetAll();
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class UsuarioServices : IUsuarioServices
    {
        private readonly EleccionesContext _dbContext;

        public UsuarioServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Usuario> GetAll()
        {
            return _dbContext.Usuarios.ToList();
        }
    }
}
