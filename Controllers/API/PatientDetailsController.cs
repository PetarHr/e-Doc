using eDoc.Models.View.Patient;
using eDoc.Services;
using Microsoft.AspNetCore.Mvc;


namespace eDoc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientDetailsController(IPatientService patientService)
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
