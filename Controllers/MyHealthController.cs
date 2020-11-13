using eDoc.Models.View.MyHealth;
using eDoc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    public class MyHealthController : Controller
    {
        private readonly IMyHealthService _healthService;

        public MyHealthController(IMyHealthService healthService)
        {
            this._healthService = healthService;
        }


        public IActionResult Details()
        {
            var myHealth = _healthService.GetMyHealthStats();

            return this.View(myHealth);
        }
        public IActionResult Update()
        {
            var myHealth = _healthService.GetMyHealthStats();

            return this.View(myHealth);
        }
        [HttpPost]
        public async Task<ActionResult> Update(MyHealthDetailsViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            var myWeight = input.MyWeight;
            var myBloodPressure = input.MyBloodPressure;
            //TODO: Implement allergy list update -> var myAllergiesList = input.AllergiesList;

            await _healthService.UpdateWeight(myWeight);
            await _healthService.UpdateBloodPressure(myBloodPressure);

            return this.Redirect("/Home/Success");
        }

        public IActionResult History()
        {
            var userHistory = _healthService.GetMyHistory();

            return this.View(userHistory);
        }
    }
}
