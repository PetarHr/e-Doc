using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }

        public bool Completed { get; set; }

        public bool AllowMultiCompletion { get; set; }

    }
}