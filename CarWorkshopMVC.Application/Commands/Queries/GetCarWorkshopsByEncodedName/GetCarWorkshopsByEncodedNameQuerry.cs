using CarWorkshopMVC.Application.CarWorkshop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.Queries.GetCarWorkshopsByEncodedName
{
    public class GetCarWorkshopsByEncodedNameQuerry : IRequest<CarWorkshopDTO>
    {
        public string EncodedName { get; set; }

        public GetCarWorkshopsByEncodedNameQuerry(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
