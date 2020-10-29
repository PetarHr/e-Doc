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
        public IActionResult Dashboard()
        {
            //TODO: Да открия начин да изтегля ID-то
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModelList = patient.GetMyAmbulatoryLists(userId);
            
            return View(viewModelList);
        }
    }
}
