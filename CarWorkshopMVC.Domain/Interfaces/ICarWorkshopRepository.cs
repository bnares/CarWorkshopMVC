using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
        Task<Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<Entities.CarWorkshop?>> GetByAll();
        Task<Entities.CarWorkshop> GetByEncodedName(string encodedName);
    }
}
