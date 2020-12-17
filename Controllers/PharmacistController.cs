using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    [Authorize]
    [Authorize(Roles = "ePharmacist,GodModeAdmin")]
    public class PharmacistController : Controller
    {
        private readonly IPharmacistService _pharmacistService;
        private readonly IPatientService _patientService;

        public PharmacistController(IPharmacistService pharmacistService, 
                                    IPatientService patientService)
        {
            this._pharmacistService = pharmacistService;
            this._patientService = patientService;
        }

        public IActionResult MyWorkList()
        {
            var myWorkList = _pharmacistService.GetMyWorkList();
            return this.View(myWorkList);
        }

        public IActionResult Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction("MyWorkList");
            }
            var recipeDetails = _patientService.GetRecipeDetails(id);

            return this.View(recipeDetails);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(string id)
        {
            await _pharmacistService.CompleteAsync(id);

            return this.RedirectToAction("MyWorkList");
        }

    }
}
