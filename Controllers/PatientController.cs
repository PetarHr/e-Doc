using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eDoc.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patient;

        public PatientController(IPatientService patient)
        {
            this.patient = patient;
        }
        [Authorize]
        public IActionResult MyRecipes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myRecipesList = patient.GetMyRecipes(userId);

            return View(myRecipesList);
        }

        [Authorize]
        public IActionResult MyAmbulatoryLists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myAmbulatoryLists = patient.GetMyAmbulatoryLists(userId);

            return View(myAmbulatoryLists);
        }
    }
}
