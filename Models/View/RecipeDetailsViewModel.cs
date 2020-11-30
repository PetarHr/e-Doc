using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View
{
    public class RecipeDetailsViewModel
    {
        public string RecipeId { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorUIN { get; set; }
        public string MedCenterName { get; set; }
        public string MedCenterAddress { get; set; }
        public string PatientFullName { get; set; }
        public string PatientPIN { get; set; }
        public string PatientAddress { get; set; }
        public DateTime RecipeCreationDate { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeCompleted { get; set; }
        public string AllowMultiCompletion { get; set; }
    }
}
