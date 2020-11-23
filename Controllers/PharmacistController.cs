using eDoc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    public class PharmacistController : Controller
    {
        private readonly IPharmacistService _pharmacistService;

        public PharmacistController(IPharmacistService pharmacistService)
        {
            this._pharmacistService = pharmacistService;
        }

        public IActionResult MyWorkList()
        {
            var myWorkList = _pharmacistService.GetMyWorkList();
            return this.View(myWorkList);
        }

        public IActionResult Find(string id)
        {
            var recipeDetails = _pharmacistService.Find(id);

            return this.View(recipeDetails);
        }

        public async Task<IActionResult> Complete(string id)
        {
            await _pharmacistService.CompleteAsync(id);

            return this.RedirectToAction("Find");
        }

    }
}
