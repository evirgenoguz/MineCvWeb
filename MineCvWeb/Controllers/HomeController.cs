using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MineCvWeb.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MineCvWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            User user = new User();
            try
            {

                user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                return View(user);
                
            } catch (Exception e)
            {

            }


                return View();
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
}