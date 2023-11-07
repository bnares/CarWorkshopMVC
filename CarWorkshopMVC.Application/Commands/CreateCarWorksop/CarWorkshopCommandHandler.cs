using AutoMapper;
using CarWorkshopMVC.Application.ApplicationUser;
using CarWorkshopMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.CreateCarWorksop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken) // bez <Unit>
        {
            //var currentUser = _userContext.GetCurrentUser();
            //if (currentUser == null || !currentUser.IsInRole("Owner"))
            //{
            //    return Unit.Value;
            //}
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || currentUser.IsInRole("Owner")) {
                throw new Exception();
            }
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();

            carWorkshop.CreatedById = currentUser.Id;
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);

            // niepotrzeba return Unit.Value (jako że jest to task)

        }
    }
}
