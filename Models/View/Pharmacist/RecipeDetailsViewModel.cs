using System;

namespace eDoc.Models.View.Pharmacist
{
    public class RecipeDetailsViewModel
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string PatientPIN { get; set; }
        public DateTime CreatedOn  { get; set; }
        public bool Completed { get; set; }
        public bool AllowMultiCompletion { get; set; }
    }
}
