using eDoc.Data.Models;
using eDoc.Models.Input;
using eDoc.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eDoc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorController(IDoctorService service, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this._userManager = userManager;
        }

        public IActionResult CreateRecipe()
        {
            var patientsList = _service.GetAllPatients();

            return this.View(patientsList);
        }

        [HttpPost]
        public IActionResult CreateRecipe(CreateRecipeInputModel input)
        {
            _service.CreateRecipe(input);

            return Redirect("/");
        }

        public IActionResult CreateAmbulatoryList()
        {
            var allPatients = _service.GetAllPatients();
            var doctor = _userManager.GetUserAsync(User).GetAwaiter().GetResult();

            var createAmbulatoryListModel = new AmbulatoryListInputModel
            {
                PatientsList = allPatients,
                DoctorId = doctor.Id,
                DoctorFullName = doctor.FullName
            };

            return this.View(createAmbulatoryListModel);
        }

        [HttpPost]
        public IActionResult CreateAmbulatoryList(AmbulatoryListInputModel input)
        {
            _service.CreateAmbulatoryList(input);

            return this.Redirect("/");
        }
    }
}

