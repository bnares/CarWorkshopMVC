using CarWorkshopMVC.Application.ApplicationUser;
using CarWorkshopMVC.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopServiceRepository carWorkshopServiceRepository,IUserContext userContext, ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
            _userContext = userContext;
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);
            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkShop.CreatedById == user.Id || user.IsInRole("Moderator"));
            if (isEditable)
            {
               throw new ();
            }
            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkShop.Id,
            };
            await _carWorkshopServiceRepository.Create(carWorkshopService);
        }
    }
}
