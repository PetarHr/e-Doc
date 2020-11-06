using eDoc.Data.Models;
using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eDoc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService service;
        private readonly UserManager<ApplicationUser> userManager;

        public DoctorController(IDoctorService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }
  
        public IActionResult CreateRecipe ()
        {
            //var patientsList = service.GetAllPatients();

            return this.View();
        }

        [HttpPost]
        public IActionResult CreateRecipe(string patientFullName, string recipeDescription)
        {
            var doctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            service.CreateRecipe(doctorId, patientFullName, recipeDescription);

            return Redirect("/");
        }
    }
}
