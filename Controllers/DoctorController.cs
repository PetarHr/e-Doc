using eDoc.Data.Models;
using eDoc.Models.Input;
using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorController(IDoctorService doctorService, 
                                UserManager<ApplicationUser> userManager)
        {
            this._doctorService = doctorService;
            this._userManager = userManager;
        }

        public IActionResult CreateRecipe()
        {
            var recipeModel = _doctorService.PrepareRecipeInputModel();

            return this.View(recipeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRecipe(CreateRecipeInputModel input)
        {
            _doctorService.CreateRecipe(input);

            return Redirect("/");
        }

        public IActionResult CreateAmbulatoryList()
        {
            var ambListInputModel = _doctorService.PrepareAmbListInputModel();

            return this.View(ambListInputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAmbulatoryList(AmbulatoryListInputModel input)
        {
            _doctorService.CreateAmbulatoryList(input);

            return this.Redirect("/");
        }

        public IActionResult CreateSickLeaveList()
        {
            var sickLeaveInputModel = _doctorService.PrepareSickLeaveInputModel();

            return this.View(sickLeaveInputModel);
        }

        [HttpPost]
        public IActionResult CreateSickLeaveList(SickLeaveListInputModel input)
        {
            _doctorService.CreateSickLeaveList(input);

            return this.Redirect("/");
        }

        public IActionResult MyPatients()
        {
            var doctorId = _userManager.GetUserAsync(User).GetAwaiter().GetResult().Id;

            var myPatients = _doctorService.GetDoctorPatients(doctorId);

            return this.View(myPatients);
        }

        public IActionResult IssuedRecipes()
        {
            var issuedRecipes = _doctorService.GetRecipesIssueByMe();
            return this.View(issuedRecipes);
        }


        public IActionResult IssuedAmbulatoryLists()
        {
            var issuedLists = _doctorService.GetAmbulatoryListsIssueByMe();
            return this.View(issuedLists);
        }

        public IActionResult IssuedSickLeaveLists()
        {
            var issuedSickLeaves = _doctorService.GetSickLeavesIssueByMe();
            return this.View(issuedSickLeaves);
        }

        

    }
}

