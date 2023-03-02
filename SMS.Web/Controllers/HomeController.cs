using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;

namespace SMS.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = "The time Now is";
        ViewBag.LongTime = DateTime.Now.ToLongDateString();
        return View();
    }

    public IActionResult About()
    {   
        // get data from Db
        
        var about = new AboutViewModel {
            Title = "About Us",
            Message = "We are a consultancy company specialising in web applications development on the .NET platform.......",
            Formed = new DateTime(2020,1,10)
        };
        
        return View(about);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
