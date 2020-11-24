using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eDoc.Models;
using Microsoft.AspNetCore.Authorization;


namespace eDoc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Legal()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HospitalsNearMe()
        {
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
    }
}
