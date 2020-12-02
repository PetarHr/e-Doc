using eDoc.Models.View.Patient;
using eDoc.Services;
using Microsoft.AspNetCore.Mvc;

namespace eDoc.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public APIController(IPatientService patientService)
        {
            this._patientService = patientService;
        }
        [HttpGet]
        public ActionResult<PatientDetailsViewModel> Get(string id)
        {
            return this._patientService.GetPatientDetails(id);
        }

    }
}
