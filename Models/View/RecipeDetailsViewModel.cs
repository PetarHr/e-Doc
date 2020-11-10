using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View
{
    public class RecipeDetailsViewModel
    {
        public string Id { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorFamilyName { get; set; }
        public string DoctorUIN { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientFamilyName { get; set; }
        public string PatientPIN { get; set; }
        public string RecipeDescription { get; set; }
        public DateTime RecipeCreationDate { get; set; }
        public string RecipeCompleted { get; set; }
        public string AllowMultiCompletion { get; set; }
    }
}
