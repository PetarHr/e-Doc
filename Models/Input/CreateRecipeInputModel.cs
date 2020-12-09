using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.Input
{
    public class CreateRecipeInputModel
    {
        public List<ApplicationUser> PatientsList { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialtyCode { get; set; }
        public string DoctorUIN { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public bool AllowMultiCompletion { get; set; }
    }
}
