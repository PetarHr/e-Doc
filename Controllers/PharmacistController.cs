using eDoc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
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
            var recipeDetails = _patientService.GetRecipeDetails(id);

            return this.View(recipeDetails);
        }

        public async Task<IActionResult> Complete(string id)
        {
            await _pharmacistService.CompleteAsync(id);

            return this.RedirectToAction("Find");
        }

    }
}
