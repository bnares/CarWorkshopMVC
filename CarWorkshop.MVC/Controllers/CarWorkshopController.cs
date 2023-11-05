
using CarWorkshopMVC.Application.Commands.CreateCarWorksop;
using CarWorkshopMVC.Application.Commands.Queries.GeetAllCarWorkshops;
using CarWorkshopMVC.Application.Commands.Queries.GetCarWorkshopsByEncodedName;
using CarWorkshopMVC.Application.Services;
using CarWorkshopMVC.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;
        private readonly IMediator _mediator;

        public CarWorkshopController(ICarWorkshopService carWorkshopService, IMediator mediator)
        {
            _carWorkshopService = carWorkshopService;
            _mediator = mediator;
        }

        public async  Task<IActionResult> Index()
        {
            // var carWorkshops = await _carWorkshopService.GetAll();
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuerry());
            return View(carWorkshops);
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async  Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send( new GetCarWorkshopsByEncodedNameQuerry(encodedName));
            return View(dto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
