using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person() {FirstName="Piotr", LastName="Ostrouch"},
            new Person(){FirstName="Adam", LastName="Małysz"}
        };
        return View(model);
    }

    public IActionResult About()
    {
        var testArray =new string[]{ "wow", "lol"};
        var model = new AboutModel() { Title = "Model About", Description = "Display standard About model",
            Tags =testArray,
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
