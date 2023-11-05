using AutoMapper;
using CarWorkshopMVC.Application.CarWorkshop;
using CarWorkshopMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.Queries.GeetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuerryHandler : IRequestHandler<GetAllCarWorkshopsQuerry, IEnumerable<CarWorkshopDTO>>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetAllCarWorkshopsQuerryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkshopDTO>> Handle(GetAllCarWorkshopsQuerry request, CancellationToken cancellationToken)
        {
            var carWorksops = await _carWorkshopRepository.GetByAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDTO>>(carWorksops);
            return dtos;
        }
    }
}
