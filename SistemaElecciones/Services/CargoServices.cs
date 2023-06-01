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
    }
}

