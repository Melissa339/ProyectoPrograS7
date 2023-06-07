using SistemaElecciones.Models;

namespace SistemaElecciones.Services
{
    public interface IMesaServices
    {
        List<Mesa> GetAll();
        void DeleteMesa(Guid id);
        int AddMesa(Mesa Mesa);
        void AddVoto(Guid id);

    }
    public class MesaServices : IMesaServices
    {
        private readonly EleccionesContext _dbContext;

        public MesaServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Mesa GetMesa(Guid id)
        {
            //return _dbContext.Usuarios.Find(id);
            return _dbContext.Mesas.FirstOrDefault(p => p.IdMesa == id);
        }
        public List<Mesa> GetAll()
        {
            return _dbContext.Mesas.ToList();
        }


        public void DeleteMesa(Guid id)
        {
            var mesa = GetMesa(id);
            if(mesa != null)
            {
                _dbContext.Mesas.Remove(mesa);
                _dbContext.SaveChanges();
            }

        }

        public int AddMesa(Mesa Mesa)
        {
            try
            {
                Guid newGuid = Guid.NewGuid();
                var MesaOnDb = _dbContext.Mesas.FirstOrDefault(x => x.IdMesa == Mesa.IdMesa);
                if (MesaOnDb is not null) return 2;
                Mesa.IdMesa = newGuid;
                _dbContext.Mesas.Add(Mesa);
                _dbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 3;
            }
        }

        public void AddVoto(Guid id)
        {
            var mesaDB = GetMesa(id);
            if (mesaDB is not null)
            {
                if (mesaDB.CantidadVotos == null)
                {
                    mesaDB.CantidadVotos = 1;
                    mesaDB.BeforeSaveChanges();
                    _dbContext.SaveChanges();
                }
                else
                {
                    mesaDB.CantidadVotos += 1;
                    mesaDB.BeforeSaveChanges();
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
