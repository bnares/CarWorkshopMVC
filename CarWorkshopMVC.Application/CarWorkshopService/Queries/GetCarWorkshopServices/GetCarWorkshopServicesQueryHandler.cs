using AutoMapper;
using CarWorkshopMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{
    public class GetCarWorkshopServicesQueryHandler: IRequestHandler<GetCarWorkshopServicesQuery, IEnumerable<CarWorkshopSericeDto>>
    {
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopServicesQueryHandler(ICarWorkshopServiceRepository carWorkshopServiceRepository, IMapper mapper)
        {
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkshopSericeDto>> Handle(GetCarWorkshopServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _carWorkshopServiceRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<CarWorkshopSericeDto>>(result);

            return dtos;
        }
    }
}
