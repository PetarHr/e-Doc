using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eDoc.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }

        public IActionResult MyRecipes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myRecipesList = service.GetMyRecipes(userId);

            return View(myRecipesList);
        }
        public IActionResult RecipeDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

            }
            var recipeDetails = service.GetRecipeDetails(id);

            return View(recipeDetails);
        }

        public IActionResult MyAmbulatoryLists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myAmbulatoryLists = service.GetMyAmbulatoryLists(userId);

            return View(myAmbulatoryLists);
        }

        public IActionResult MyDoctor()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myDoctor = service.GetMyDoctor(userId);

            if (myDoctor == null)
            {
                return View("MissingDoctor");
            }
            return this.View(myDoctor);
        }
    }
}
