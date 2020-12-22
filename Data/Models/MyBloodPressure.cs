using eDoc.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class MyBloodPressure
    {
        public MyBloodPressure()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Моля, въведете валидна стойност за диастолично налягане.")]
        public double Systolic { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Моля, въведете валидна стойност за систолично налягане.")]
        public double Diastolic { get; set; }
        public DateTime RecordDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}