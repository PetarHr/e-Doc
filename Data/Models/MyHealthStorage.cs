using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class MyHealthStorage
    {
        public string Id { get; set; }
        public DateTime RecordDate { get; set; }
        public double Weight { get; set; }
        public double BloodPressure { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
