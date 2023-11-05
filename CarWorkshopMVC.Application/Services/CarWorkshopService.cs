using AutoMapper;
using CarWorkshopMVC.Application.CarWorkshop;
using CarWorkshopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task Create(CarWorkshop.CarWorkshopDTO carWorkshopDTO)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDTO);
            carWorkshop.EncodeName();
            await _carWorkshopRepository.Create(carWorkshop);

        }

        public async Task<IEnumerable<CarWorkshopMVC.Application.CarWorkshop.CarWorkshopDTO?>> GetAll()
        {
            var carWorkshops = await _carWorkshopRepository.GetByAll();
            var mapper = _mapper.Map<List<CarWorkshopDTO>>(carWorkshops);
            return mapper;
        }
    }
}
