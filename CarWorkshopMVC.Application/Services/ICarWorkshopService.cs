using CarWorkshopMVC.Domain.Entities;

namespace CarWorkshopMVC.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshop.CarWorkshopDTO carWorkshop);
        Task<IEnumerable<CarWorkshopMVC.Application.CarWorkshop.CarWorkshopDTO>> GetAll();
    }
}