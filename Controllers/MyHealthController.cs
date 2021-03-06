﻿using eDoc.Models.View.MyHealth;
using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Controllers
{
    [Authorize]
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(MyHealthDetailsViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            var myWeight = input.MyWeight;
            var myBloodPressure = input.MyBloodPressure;

            await _healthService.UpdateWeight(myWeight);
            await _healthService.UpdateBloodPressure(myBloodPressure);

            return this.RedirectToAction("Details");
        }

        public IActionResult History()
        {
            var userHistory = _healthService.GetMyHistory();

            return this.View(userHistory);
        }

        public IActionResult Remove(string id)
        {
            _healthService.RemoveRecord(id);

            return this.RedirectToAction("History");
        }
    }
}
