using eDoc.Data.Models;
using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eDoc.Controllers
{
    [Authorize]
    [Authorize(Roles = "ePatient,GodModeAdmin, eDoctor")]
    public class PatientController : Controller
    {
        private readonly IPatientService service;
        private readonly UserManager<ApplicationUser> userManager;

        public PatientController(IPatientService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public IActionResult MyRecipes()
        {
            var userId = userManager.GetUserId(this.User);

            var myRecipesList = service.GetMyRecipes(userId);

            return View(myRecipesList);
        }
        public IActionResult RecipeDetails(string id)
        {
            var recipeDetails = service.GetRecipeDetails(id);

            return View(recipeDetails);
        }
        public IActionResult AmbulatoryListDetails(string id)
        {
            var ambulatoryListDetails = service.GetAmbulgatoryListDetails(id);

            return View(ambulatoryListDetails);
        }

        public IActionResult SickLeaveDetails(string id)
        {
            var sickLeave = service.GetSickLeaveDetails(id);

            return View(sickLeave);
        }

        public IActionResult MyAmbulatoryLists()
        {
            var userId = userManager.GetUserId(this.User);

            var myAmbulatoryLists = service.GetMyAmbulatoryLists(userId);

            return View(myAmbulatoryLists);
        }
        public IActionResult MySickLeaveLists()
        {
            var userId = userManager.GetUserId(this.User);

            var mySickLeaveLists = service.GetMySickLeaveLists(userId);

            return View(mySickLeaveLists);
        }

        public IActionResult MyDoctor()
        {
            var myDoctor = service.GetMyDoctor();

            if (myDoctor == null)
            {
                return View("MissingDoctor");
            }
            return this.View(myDoctor);
        }

        public IActionResult ListAllDoctors()
        {

            var doctorsList = service.GetDoctorsLists();

            return this.View(doctorsList);
        }

        public IActionResult RemoveMyDoctor()
        {
            service.RemoveMyDoctor();

            return this.RedirectToAction("MyDoctor");
        }

        public IActionResult AssignDoctor(string doctorId)
        {

            service.AssignDoctor(doctorId);

            return this.RedirectToAction("MyDoctor");
        }
    }
}
