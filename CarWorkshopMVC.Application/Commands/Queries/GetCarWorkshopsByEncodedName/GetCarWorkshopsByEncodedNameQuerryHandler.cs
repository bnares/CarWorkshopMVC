using AutoMapper;
using CarWorkshopMVC.Application.CarWorkshop;
using CarWorkshopMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.Queries.GetCarWorkshopsByEncodedName
{
    public class GetCarWorkshopsByEncodedNameQuerryHandler : IRequestHandler<GetCarWorkshopsByEncodedNameQuerry, CarWorkshopDTO>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopsByEncodedNameQuerryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<CarWorkshopDTO> Handle(GetCarWorkshopsByEncodedNameQuerry request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<CarWorkshopDTO>(carWorkshop);
            return dto;
        }
    }
}
