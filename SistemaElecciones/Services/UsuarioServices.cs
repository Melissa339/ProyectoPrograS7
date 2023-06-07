using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IUsuarioServices
    {
        List<Usuario> GetAll();
        Usuario Authenticate(string user, string password);

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

        public Usuario Authenticate(string user, string password)
        {
            var userItem = _dbContext.Usuarios.FirstOrDefault(x => x.Password == password && x.Nombre == user);
            return userItem;
        }
    }
}
