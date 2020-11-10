using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.Input
{
    public class CreateRecipeInputModel
    {
        public string DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientId { get; set; }
        public string PatientFullName { get; set; }
        public string RecipeDescription { get; set; }
        public bool AllowMultiCompletion { get; set; }
    }
}
