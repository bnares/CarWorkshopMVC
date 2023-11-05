using CarWorkshopMVC.Application.CarWorkshop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Commands.CreateCarWorksop
{
    public class CreateCarWorkshopCommand : CarWorkshopDTO, IRequest
    {

    }
}
