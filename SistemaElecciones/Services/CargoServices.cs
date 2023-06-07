using SistemaElecciones.Models;
//using SistemaElecciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaElecciones.Services
    {
        public interface ICargoServices
    {
        List<Cargo> GetAll();
        void Add(Cargo cargo);
        void DeleteCargo(Guid id);
        //void Add(Cita cita);
        //void Delete(Guid id);
    }
    public class CargoServices : ICargoServices
    {
        private readonly EleccionesContext _dbContext;
        public CargoServices(EleccionesContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<Cargo> GetAll()
        {
            return _dbContext.Cargos.ToList();
        }

        public void Add(Cargo cargo)
        {
            cargo.IdCargo = Guid.NewGuid();
            cargo.EstadoEliminado = false;
            cargo.BeforeSaveChanges();
            _dbContext.Cargos.Add(cargo);
            _dbContext.SaveChanges();
        }

        public Cargo? Get(Guid id)
        {
            return _dbContext.Cargos.FirstOrDefault(x => x.IdCargo == id);
        }

        public void DeleteCargo(Guid id)
        {
            var cargo = Get(id);
            if (cargo is not null)
            {
                cargo.EstadoEliminado = true;
                _dbContext.SaveChanges();
            }
        }
    }
}

