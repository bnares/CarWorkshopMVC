using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommand : CarWorkshopSericeDto, IRequest
    {
        public string CarWorkshopEncodedName { get; set; } = default;
    }
}
