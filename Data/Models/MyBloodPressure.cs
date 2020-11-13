using eDoc.Data.Models;
using System;
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
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public DateTime RecordDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}