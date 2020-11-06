using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models
{
    public class RecipeListViewModel
    {
        public string PatientId { get; set; }
        public string Number { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientFullName { get; set; }
        public DateTime IssueDate { get; set; }
        public string RecipeDescription { get; set; }

        public string Completed { get; set; }

        public string AllowMultiCompletion { get; set; }


    }
}
