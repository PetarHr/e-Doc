using eDoc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eDoc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctor;

        public DoctorController(IDoctorService doctor)
        {
            this.doctor = doctor;
        }
  
        public IActionResult CreateRecipe ()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateRecipe(string doctorId, string patientId,
                                            string description)
        {


            return this.View();
        }
    }
}
