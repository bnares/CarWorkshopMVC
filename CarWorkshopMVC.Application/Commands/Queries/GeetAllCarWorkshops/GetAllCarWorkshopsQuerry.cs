using CarWorkshopMVC.Application.CarWorkshop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.Queries.GeetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuerry : IRequest<IEnumerable<CarWorkshopDTO>>
    {

    }
}
