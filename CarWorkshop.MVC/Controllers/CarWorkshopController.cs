
using CarWorkshop.MVC.Extensions;
using CarWorkshop.MVC.Models;
using CarWorkshopMVC.Application.CarWorkshopService.Commands;
using CarWorkshopMVC.Application.Commands.CreateCarWorksop;
using CarWorkshopMVC.Application.Commands.Queries.GeetAllCarWorkshops;
using CarWorkshopMVC.Application.Commands.Queries.GetCarWorkshopsByEncodedName;
using CarWorkshopMVC.Application.Services;
using CarWorkshopMVC.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        [Authorize(Roles ="Owner")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            
            //TempData["Notification"] = JsonConvert.SerializeObject(notification);
            this.SetNotification("success", $"Created {command.Name}");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles ="Owner")]
        [Route("CarWorkshop/CarWorkshopService")]
        public async Task<IActionResult> CreateCarWorkshopService(CreateCarWorkshopServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(command);
            return Ok();
        }
    }
}
