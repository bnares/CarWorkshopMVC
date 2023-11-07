using CarWorkshopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Domain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task Create(CarWorkshopService carWorkshopService);
    }
}
