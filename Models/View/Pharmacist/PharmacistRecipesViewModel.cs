using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View.Pharmacist
{
    public class PharmacistRecipesViewModel
    {
        public string RecipeId { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Completed { get; set; }
        public string AllowMultiCompletion { get; set; }
    }
}
