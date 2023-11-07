using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{

    public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopSericeDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
